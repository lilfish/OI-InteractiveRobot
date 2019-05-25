import sys
import socket
import time
import asyncio
import websockets
import json
import pickle

print("running Socket Server")

async def scamera(websocket, path):
	name = await websocket.recv()
	print(f"< {name}")
	# Ryan code hier!
	# Start: Detectie code
	fp = open("data.pkl","rb")
	data = pickle.load(fp)
	# Stop: communicatie gaat hier verder
	myJson = json.dumps(data)
	print(f"> {data}")
	await websocket.send(myJson);

start_server = websockets.serve(scamera, 'localhost', 1337)

asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()

