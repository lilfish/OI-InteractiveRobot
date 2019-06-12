from flask import Flask
app = Flask(__name__)
import json

x = 13
y = 37
emotion = "blij"
# Ryan code hier!
# Start: Detectie code
#
# Stop: communicatie gaat hier verder
data = {
    "x": str(x),
    "y": str(y),
    "emotion": "blij"
}
myJson = json.dumps(data)

@app.route('/')
def hello_world():
    return myJson