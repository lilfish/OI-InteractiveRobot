import sys
import os
import json

my_details = {  
    "posx":640,
    "posy":123,
    "emotion":"neutral",
    "id":str(-1),
    "my_width":1920,
    "my_height":1080,
}

with open ("../ThreeJS/data.json","w") as json_file:
    json.dump(my_details, json_file)
