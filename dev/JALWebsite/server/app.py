from flask import Flask, jsonify
from flask_cors import CORS
import random

app = Flask(__name__)
CORS(app)

stringTest = "howdy dis from backend"

@app.route('/getBackendTest')
def getBackendTest():
    return jsonify({'stringTest': stringTest})

if __name__ == '__main__':
    app.run(debug=True, port=8080)