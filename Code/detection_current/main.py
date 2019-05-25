import cv2
import sys
import os
import openvino
import pickle

from detector import *  # detection system 
from objects import *   # all object classes 
from utils import *     # helping utilities 

# OpenVino Detection Models
#  You will have to change the location of cpu_extension to match your version of openVINO when cloning
#  this is tested on (2019.1.144 & 2019.1.133)
printInfo()

# Facedetector using MYRIAD X (intel VPU) to detect faces. only use FP16 models on myriad.
# if run on CPU/GPU use the FP32 models.
face_detector = FaceDetector(           model_xml="./assets/face_detection/FP32/fd.xml",\
                                        model_bin="./assets/face_detection/FP32/fd.bin",\
                                        device="CPU",\
                                        confidence_threshold=0.50,\
                                        cpu_extension="/opt/intel/openvino_2019.1.144/inference_engine/lib/intel64/libcpu_extension_sse4.so")

# Running on GPU using FP32. do not run with MYRIAD!
emotion_classifier = EmotionClassifier( model_xml="./assets/emotion_recognition/FP32/em.xml",\
                                        model_bin="./assets/emotion_recognition/FP32/em.bin",\
                                        device="CPU", 
                                        cpu_extension="/opt/intel/openvino_2019.1.144/inference_engine/lib/intel64/libcpu_extension_sse4.so",\
                                        emotion_label_list=["neutral", "happy", "sad", "surprise", "anger"])

# 3840 1920
# 2160 1080

# Start Camera (OPENCV) 
cap = cv2.VideoCapture(0)
cap.set(cv2.CAP_PROP_FRAME_WIDTH, 1920)
cap.set(cv2.CAP_PROP_FRAME_HEIGHT, 1080)



previousDetectedHumans = []

while True:

    # get frame, if frame not present return (stop)
    videoFrame, img = cap.read()
    if not videoFrame:
        print("ERROR: Camera Disconnected")
        break

    # get detected faces from openvino inference engine:
    humans = detectHumans(img, face_detector, emotion_classifier,previousDetectedHumans)
    previousDetectedHumans = humans

    #Show detected data on screen
    for human in humans:
        print(human.uniqueID)
        img = human.visualise(img)
        data = {
		"posx":human.face.location.get_centroid().x,
		"posy":human.face.location.get_centroid().y,
		"emotion":human.emotion
		}
        fp = open("data.pkl","wb")
        pickle.dump(data, fp)
        fp.close()

    img = displayFPS(img)
    cv2.imshow("HumanFaceDetection",img)

    # exit condition ! always under the code for preformance
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
        
cv2.destroyAllWindows()
cap.release()
