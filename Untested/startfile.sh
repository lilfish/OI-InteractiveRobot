#!/bin/bash


cd /home/up2/oi_finalProduct/oi_robot_interaction/Untested/detection_module
source /home/up2/anaconda3/bin/activate faceDetect
source /opt/intel/openvino_2019.1.133/bin/setupvars.sh
python main.py &
sleep 10 && firefox ../three_module/index.html &
