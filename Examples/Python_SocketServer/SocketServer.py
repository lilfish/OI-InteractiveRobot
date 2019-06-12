import sys
import socket
import time
import asyncio
import websockets
import json

async def camera(websocket, path):
	name = await websocket.recv()
	print(f"< {name}")
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
	print(f"> {data}")
	await websocket.send(myJson);

start_server = websockets.serve(hello, server_ip, 1337)

asyncio.get_event_loop().run_until_complete(camera)
asyncio.get_event_loop().run_forever()
