import cv2
import os
import openvino
from models import FaceDetector
from utils import SyFrame
from utils import draw_bounding_box

face_xml="./assets/face_detection/FP16/fd.xml"
face_bin="./assets/face_detection/FP16/fd.bin"

face_detector = FaceDetector(model_xml=face_xml,\
                             model_bin=face_bin,\
                             device="MYRIAD",\
                             confidence_threshold=0.2,\
                             cpu_extension="/opt/intel/openvino_2019.1.133/inference_engine/lib/intel64/libcpu_extension_sse4.so")

cap = cv2.VideoCapture(0)
cap.set(cv2.CAP_PROP_FRAME_WIDTH, 1920)
cap.set(cv2.CAP_PROP_FRAME_HEIGHT, 1080)

while True:
    ret, img = cap.read()
    detected_faces=face_detector.detect(SyFrame(img))
    

    for face in detected_faces:
        
        tracker.init(frame, face)
        sq_loc = face.get_square_location()
        blur_face = face.get_square_frame_region().frame
        #face.label.
        blur_face = cv2.blur(blur_face,(45,45))
   
        #cv2.Scalar color = cv.Scalar( 94, 206, 165 )
        #blur_face = cv2.rectangle(blur_face,sq_loc.x,sq_loc.x,cv2.color,3)
        
        

        img[sq_loc.y:sq_loc.y+blur_face.shape[0], sq_loc.x:sq_loc.x+blur_face.shape[1]] = blur_face

    cv2.imshow("Demo",img)

    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
        
cv2.destroyAllWindows()
cap.release()
