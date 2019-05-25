import os
import cv2

# Commandline feedback 
def printInfo():      
    print()
    print("---------------------------------------------------------")
    print("Open Innovation - Fontys university of applied sciences ")
    print()
    print(" Robot Interaction (human Location module)")
    print(" face detection &  emotion classifier with openvino ")
    print("---------------------------------------------------------")
    #open CV check
    print("Camera system:")
    print()
    print("Running on openCV version: "+ cv2.__version__)
    #Camera Module check
    os.system('v4l2-ctl --list-devices')
    print("---------------------------------------------------------")


