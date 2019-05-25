import os
import logging
from openvino.inference_engine import IENetwork, IEPlugin
import copy
import uuid
import cv2
import numpy as np

from objects import *


def detectHumans(img, face_detector, emotion_classifier, previousDetectedHumans):
    currentDetectedHumans = []
    detected_faces=face_detector.detect(SyFrame(img))
    for face in detected_faces:
        
        # get emotion from openvino inference engine:
        emotion = emotion_classifier.predict(face.get_square_frame_region().frame)

        # make sure humans get the same ID 
        currenthuman = Human(face,emotion,face.region_id)
        for previousHuman in previousDetectedHumans:
            currentHumanPosition = currenthuman.face.location.get_centroid()
            previousHumanPosition = previousHuman.face.location.get_centroid()
            if previousHumanPosition.x-75 <= currentHumanPosition.x <= previousHumanPosition.x+75:
                if previousHumanPosition.y-75 <= currentHumanPosition.y <= previousHumanPosition.y+75:
                    currenthuman.uniqueID = previousHuman.uniqueID
        
        currentDetectedHumans.append(currenthuman)
        img = currenthuman.visualise(img)      # add detected Human to output frame
    
    previousDetectedHumans = currentDetectedHumans.copy()   
    return currentDetectedHumans

def displayFPS(img):
    timer = cv2.getTickCount()
    fps = cv2.getTickFrequency() / (cv2.getTickCount() - timer)
    cv2.putText(img, "FPS : " + str(int(fps)), (40,30), cv2.FONT_HERSHEY_SIMPLEX, 0.60, (0,0,0), 1)
    return img


#----------------------------------------------------------------------------------


logger = logging.getLogger(__name__)

def make_square(x, y, w, h, max_w, max_h):
    max_dist = int(max(w, h))
    min_dist = int(min(w, h))

    semidiff = int((max_dist - min_dist) / 2)

    if max_dist == h:
        square_x_min = min(max_w, max(0, x - semidiff))
        square_y_min = max(min(y, max_h),0)
        square_x_max = min(max(0, x - semidiff + max_dist),max_w)
        square_y_max = max(0, min(y + max_dist, max_h))

    else:
        square_x_min = max(min(x, max_w), 0)
        square_y_min = min(max(0, y - semidiff), max_h)
        square_x_max = max(0,min(x + max_dist, max_w))
        square_y_max = min(max_h,max(0, y - semidiff + max_dist))

    return square_x_min, square_y_min, square_x_max, square_y_max


class SyRequest:
    def __init__(self, request, frame):
        self.request = request
        self.frame = frame

class SyRegion:
    def __init__(self, sy_frame, location=None, label=None, confidence=None, region_id=None, metadata=dict):
        self.location = location
        self.region_id = uuid.uuid4() if region_id is None else region_id
        self.label = label
        self.confidence = confidence
        self.sy_frame = sy_frame
        self.metadata = metadata

    def __repr__(self):
        return f"SyRegion(label={self.label}, location={self.location}, confidence={self.confidence}, " \
            f"region_id={self.region_id})"

    def get_frame_region(self):
        """
        Crop area near region in frame
        :return: numpy.ndarray containing the cropped frame
        """

        return self.sy_frame.frame[self.location.beginPoint.y:self.location.beginPoint.y+self.location.margin.h, self.location.beginPoint.x:self.location.beginPoint.x+self.location.margin.w]

    def get_square_frame_region(self):
        """
        Crop square area near region in frame
        :return: numpy.ndarray containing the cropped frame
        """
        square_location = self.get_square_location()

        return SyFrame(frame=self.sy_frame.frame[square_location.beginPoint.y:square_location.beginPoint.y + square_location.margin.h, square_location.beginPoint.x:square_location.beginPoint.x+square_location.margin.w], id_=self.sy_frame.id_)

    def get_square_location(self):
        """
        Crop square area near region in frame
        :return: numpy.ndarray containing the cropped frame
        """
        square_x_min, square_y_min, square_x_max, square_y_max = \
            make_square(
                self.location.beginPoint.x,
                self.location.beginPoint.y,
                self.location.margin.w,
                self.location.margin.h,
                max_w=self.sy_frame.width,
                max_h=self.sy_frame.height
            )

        return Location(x=square_x_min, y=square_y_min, w=square_x_max-square_x_min, h=square_y_max-square_y_min)
 

class SyFrame:

    def __init__(self, frame, id_=None):
        self.frame = frame
        self.id_ = uuid.uuid4() if id_ is None else id_
        self.width = frame.shape[1]
        self.height = frame.shape[0]



class ObjectDetector:
    """
    Detect objects on frames using a neural network model.
    Model must be in Intel OpenVINO IE Format

    Notes
    -----
    Model Optimizer: https://software.intel.com/en-us/articles/OpenVINO-ModelOptimizer

    Attributes
    ----------
    threshold: double
        Confidence threshold that a detections has to have to be considered valid.
    n, c, net_input_height, net_input_width: int
        Optimized model's shape.
    plugin: openvino.inference_engine.ie_api.IEPlugin
        OpenVINO inference engine plugin.
    input_layer: str
        Network's input layer's name.
    output_layer: str
        Network's output layer's name.
    exec_net: inference_engine.ie_api.ExecutableNetwork
        OpenVINO network model.
    labels: :obj:`list` of :obj:`str`:
        List of classes to which might belong detected objects
    """

    def __init__(self, model_xml, model_bin, device, cpu_extension=None, pre=None, post=None, plugin_dir=None, num_requests=1, labels=None):
        """
        Parameters
        ----------
        model_xml: str
            Xml file path (obtained with the Model Converter).
        model_bin: str
            bin file path
        device:
            Select the device you want to use to run the model (CPU, GPU, MYRIAD).
        cpu_extension: str
            CPU extension file path. Used only if device==CPU.
        plugin_dir: str
            Plugin directory path (never used, always None).
        num_requests: int
            Number of OpenVINO requests alive at the same time.
        pre: func
            Frame pre-processing (before detection) function.
        post: func
            Frame post-processing (after detection) function.
        """

        self.n = -1
        self.c = -1
        self.net_input_width = -1
        self.net_input_height = -1
        self.plugin = self._load_plugin(plugin_dir, device, cpu_extension)
        self.input_layer, self.output_layer, self.exec_net = self._read_ir(model_xml=model_xml,
                                                                           model_bin=model_bin,
                                                                           num_requests=num_requests)
        if labels:
            self.labels = labels
        self._pre = pre
        self._post = post
        self.request_id = None

    @staticmethod
    def _load_plugin(plugin_dir, device, cpu_extension=None):
        """
        Loads OpenVINO plugin

        Returns
        -------
        openvino.inference_engine.ie_api.IEPlugin:
            OpenVINO inference engine plugin.
        """

        logger.debug("Initializing plugin for {} device from {}...".format(device, plugin_dir))
        plugin = IEPlugin(device=device, plugin_dirs=plugin_dir)
        if cpu_extension and 'CPU' in device:
            logger.debug("Loading extension: {}".format(cpu_extension))
            plugin.add_cpu_extension(cpu_extension)
        return plugin

    def _read_ir(self, model_xml, model_bin, num_requests):
        """
        Loads OpenVINO optimized model

        Parameters
        ----------
        num_requests: int
            Number of OpenVINO requests alive at the same time.

        Returns
        -------
        str:
            Network's input layer's name.
        str:
            Network's output layer's name.
        inference_engine.ie_api.ExecutableNetwork:
            OpenVINO network model.
        """


        logger.info("Reading and loading IR {}".format(model_xml))
        net = IENetwork(model=model_xml, weights=model_bin)
        assert len(net.inputs.keys()) == 1, "Object Detector supports only single input topologies"
        assert len(net.outputs) == 1, "Object Detector supports only single output topologies"
        input_layer = next(iter(net.inputs))
        output_layer = next(iter(net.outputs))
        exec_net = self.plugin.load(network=net, num_requests=num_requests)
        self.n, self.c, self.net_input_height, self.net_input_width = net.inputs[input_layer].shape
        del net
        return input_layer, output_layer, exec_net

    def preprocess(self, sy_frame, *args):
        """
        Here you can chain lots of transformation of your frame.
        You can use the default behaviour of the preprocess function, that consists in applying an identity function
        to the frame_wrapper, or you can create your behaviour extending this class.
        """
        return sy_frame


    def postprocess(self, detection_result, sy_frame, *args):
        """
        It applies some transformation on network's outputs (if you want).
        If you don't override this function, we're gonna apply the identity function.

        Parameters
        ----------
        detection_result: whatever the output of the output layer is

        Returns
        -------
        network_output: whataver the output of the output layer is
        """

        return (detection_result, sy_frame)

    def start_detection(self, sy_frame, req_id = 0):

        preprocessed_frame = self.preprocess(sy_frame)

        return SyRequest(request = self.exec_net.start_async(request_id=req_id, inputs={self.input_layer: preprocessed_frame.frame}), frame=sy_frame)

    def get_detection(self, sy_request, wait_time = -1):
        request = sy_request.request
        sy_frame = sy_request.frame

        network_output = request.outputs[self.output_layer] if request.wait(wait_time) == 0 else None

        return self.postprocess(network_output, sy_frame)

    def detect(self, sy_frame, req_id=0, wait_time=-1):
        sy_request = self.start_detection(sy_frame, req_id)
        return self.get_detection(sy_request, wait_time)

    def destroy(self):
        """
        Remove network related object from the scope.

        Returns
        -------
            None.
        """
        del self.exec_net
        del self.plugin

class ImageClassifier:

    def __init__(self, model_xml, model_bin, device, cpu_extension, plugin_dir = None, num_requests=1):
        """
        Parameters
        ----------
        model_xml: str
            Xml file path (obtained with the Model Converter).
        model_bin: str
            bin file path
        threshold: double
            Predictions with confidence under this value will be ignored.
        device:
            Select the device you want to use to run the model (CPU, GPU, MYRIAD).
        cpu_extension: str
            CPU extension file path. Used only if device==CPU.
        plugin_dir: str
            Plugin directory path (never used, always None).
        num_requests: int
            Number of OpenVINO requests alive at the same time.
        """

        self.n = -1
        self.c = -1
        self.net_input_width = -1
        self.net_input_height = -1
        self.plugin = self._load_plugin(plugin_dir, device, cpu_extension)
        self.input_layer, self.output_layer, self.exec_net = self._read_ir(model_xml = model_xml, model_bin = model_bin, num_requests = num_requests)
    @staticmethod
    def _load_plugin(plugin_dir, device, cpu_extension):
        """
        Loads OpenVINO plugin

        Returns
        -------
        openvino.inference_engine.ie_api.IEPlugin:
            OpenVINO inference engine plugin.
        """

        logger.debug("Initializing plugin for {} device...".format(device))
        plugin = IEPlugin(device=device, plugin_dirs=plugin_dir)
        if cpu_extension and 'CPU' in device:
            plugin.add_cpu_extension(cpu_extension)
        return plugin

    def _read_ir(self, model_xml, model_bin, num_requests):
        """
        Loads OpenVINO optimized model

        Parameters
        ----------
        num_requests: int
            Number of OpenVINO requests alive at the same time.

        Returns
        -------
        str:
            Network's input layer's name.
        str:
            Network's output layer's name.
        inference_engine.ie_api.ExecutableNetwork:
            OpenVINO network model.
        """

        logger.info("Reading and loading IR {}".format(model_xml))

        net = IENetwork(model=model_xml, weights=model_bin)
        assert len(net.inputs.keys()) == 1, "Image Classifier supports only single input topologies"

        input_layer = next(iter(net.inputs))
        output_layer = net.outputs
        exec_net = self.plugin.load(network=net, num_requests=num_requests)
        del net
        return input_layer, output_layer, exec_net

    def preprocess(self, frame, *args):
        return frame

    def postprocess(self, result, *args):
        return result

    def start_prediction(self, frame_wrap, req_id = 0):

        frame = self.preprocess(frame_wrap)
        self.current_frame = frame
        
        request = self.exec_net.start_async(request_id=req_id, inputs={self.input_layer: frame})

        return request

    def get_prediction(self, request, wait_time = -1):
        network_output = None
        if request.wait(wait_time) == 0:
            network_output = request


        output = dict()
        for out in self.output_layer:
            output[out] = network_output.outputs[out]

        return self.postprocess(output)

    def predict(self, frame, wait_time = -1):
        req = self.start_prediction(frame, 0)
        return self.get_prediction(req, wait_time)

    def destroy(self):
        """
        Remove network related object from the scope.

        Returns
        -------
            None.
        """
        del self.exec_net
        del self.plugin


# MODELS 


class FaceDetector(ObjectDetector):

    def __init__(self, model_xml, model_bin, device, confidence_threshold, cpu_extension=None):
        super().__init__(model_xml, model_bin, device, cpu_extension=cpu_extension)
        self.confidence_threshold = confidence_threshold

    def preprocess(self, sy_frame, *args):
        frame = copy.deepcopy(sy_frame.frame)
        resized_frame = cv2.resize(frame, (self.net_input_width, self.net_input_height))
        transposed_frame = resized_frame.transpose((2,0,1))
        return SyFrame(transposed_frame, sy_frame.id_)

    def postprocess(self, detection_result, sy_frame, *args):
        results = []

        for obj in detection_result[0][0]:
            textual_label = str(int(obj[1]))  # edited
            confidence = obj[2]

            if int((obj[1])) != -1 and confidence > self.confidence_threshold:
                x_min = max(0, int(obj[3] * sy_frame.width))
                y_min = max(0, int(obj[4] * sy_frame.height))
                x_max = int(obj[5] * sy_frame.width)
                y_max = int(obj[6] * sy_frame.height)

                result = SyRegion(label=textual_label, confidence=confidence, location=Location(x=x_min, y=y_min, w=x_max - x_min, h=y_max - y_min), sy_frame=sy_frame)

                results.append(result)

        return results
    

class EmotionClassifier(ImageClassifier):

    def __init__(self, model_xml, model_bin, device, cpu_extension, emotion_label_list=None, num_requests = 1):
        super().__init__(model_xml, model_bin, device, cpu_extension,num_requests=num_requests)
        if emotion_label_list is not None:
            self.emotion_map = emotion_label_list
        else:
            self.emotion_map = []

    def preprocess(self, frame, *args):
        emotion_img = cv2.resize(frame, (64, 64))
        emotion_img = np.transpose(emotion_img, (2, 0, 1))
        return emotion_img

    def postprocess(self, result, *args):
        key_list = list(result.keys())
        if len(key_list) == 1:
            rez = result[key_list[0]]
            emotion = np.reshape(rez, (5))
            return self.emotion_map[int(np.argmax(emotion))]
        else:
            logger.error("They key list does not match expectations.")    
    
