from flask import Flask, jsonify, render_template
from flask_cors import CORS
import random

app = Flask(__name__)
CORS(app)

stringTest = "howdy dis from backend"

@app.route('/getBackendTest')
def getBackendTest():
    return jsonify({'stringTest': stringTest})

@app.route('/')
def game():
    return render_template('index.html')

if __name__ == '__main__':
    app.run(debug=True, port=8080)