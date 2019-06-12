from flask import Flask
import json
import sys
import pickle
from flask_cors import CORS

app = Flask(__name__)
CORS(app)

@app.route('/')
def hello_world():
    fp = open("data.pkl","rb")
    data = pickle.load(fp)
    # Stop: communicatie gaat hier verder
    myJson = json.dumps(data)

    return myJson