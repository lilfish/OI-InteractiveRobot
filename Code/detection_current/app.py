from flask import Flask
app = Flask(__name__)
import json
import sys
import pickle

fp = open("data.pkl","rb")
data = pickle.load(fp)
# Stop: communicatie gaat hier verder
myJson = json.dumps(data)
myJson = json.dumps(data)

@app.route('/')
def hello_world():
    return myJson