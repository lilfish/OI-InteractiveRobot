import cv2
import sys
import os
import openvino
import numpy as np
import time
import pickle

from objects import *   # all object classes 
from utils import *     # helping utilities 

# OpenVino Detection Models
#  You will have to change the location of cpu_extension to match your version of openVINO when cloning.
#  this is tested on (2019.1.133 & 2019.1.144)
printInfo()

# Facedetector using MYRIAD X (intel VPU) to detect faces. only use FP16 models on myriad.
# if run on CPU/GPU use the FP32 models.
face_detector = FaceDetector(           model_xml="./assets/face_detection/FP16/fd.xml",\
                                        model_bin="./assets/face_detection/FP16/fd.bin",\
                                        device="MYRIAD",\
                                        confidence_threshold=0.50,\
                                        cpu_extension="/opt/intel/openvino_2019.1.133/inference_engine/lib/intel64/libcpu_extension_sse4.so")

# Running on GPU using FP32. do not run with MYRIAD!
emotion_classifier = EmotionClassifier( model_xml="./assets/emotion_recognition/FP32/em.xml",\
                                        model_bin="./assets/emotion_recognition/FP32/em.bin",\
                                        device="GPU", 
                                        cpu_extension="/opt/intel/openvino_2019.1.133/inference_engine/lib/intel64/libcpu_extension_sse4.so",\
                                        emotion_label_list=["neutral", "happy", "sad", "surprise", "anger"])

# 1280 1920
# 720 1080

# Start Camera (OPENCV) 
cap = cv2.VideoCapture(0)
cap.set(cv2.CAP_PROP_FRAME_WIDTH, 1280)
cap.set(cv2.CAP_PROP_FRAME_HEIGHT, 720)

frame = Frame( np.zeros((720,1280,3), np.uint8))
printInfoDone()

my_width = (int(cap.get(cv2.CAP_PROP_FRAME_WIDTH)))
my_height = (int(cap.get(cv2.CAP_PROP_FRAME_HEIGHT)))

while True:

    #timer for FPS
    timer = cv2.getTickCount()

    # get frame, if frame not present return (stop)
    videoFrame, img = cap.read()
    # img = cv2.flip(img, 1) - we don't need to flip since the screen is inverted
    if not videoFrame:
        print("ERROR: Camera Disconnected")
        break

    # add the image as frame to calculate subframes.
    frame.NewFrame(img)

    # detect all humans in subframes and add them to the frame
    frame.DetectHumans(face_detector,emotion_classifier)
    
    largest = 0
    closest = None
    for human in frame.humans:
        size = human.face.location.get_surface() #returned int
        if size > largest:
            largest = size
            closest = human
    if closest != None:
        img = closest.visualise(img)
        data = {
		"posx":closest.face.location.get_centroid().x,
		"posy":closest.face.location.get_centroid().y,
		"emotion":closest.emotion,
        "id":str(closest.uniqueID),
        "my_width":my_width,
        "my_height":my_height,
		}
        fp = open("data.pkl","wb")
        pickle.dump(data, fp)
        fp.close()
    else:
        data = {
		"posx":640,
		"posy":360,
		"emotion":"neutral",
        "id":str(-1),
        "my_width":my_width,
        "my_height":my_height,
		}
        fp = open("data.pkl","wb")
        pickle.dump(data, fp)
        fp.close()
    
    #  DEBUG: Show detected data on screen----------------------------------------------------------
#    for human in frame.humans:
#        print(human.uniqueID)
#        img = human.visualise(img)
    
    # FPS counter & Image show
    fps = cv2.getTickFrequency() / (cv2.getTickCount() - timer)
    cv2.putText(img, "FPS : " + str(int(fps)), (40,30), cv2.FONT_HERSHEY_SIMPLEX, 0.60, (0,0,0), 1)
    # cv2.imshow("HumanFaceDetection",img)
    # /DEBUG ---------------------------------------------------------------------------------------
    
    # exit condition ! always under the code for preformance
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
        
cv2.destroyAllWindows()
cap.release()
