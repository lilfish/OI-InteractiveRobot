import sys
import socket
import time
import asyncio
import websockets
import json

def sendCoords(x, y):
	# Ryan hier!
	data = {
		"x": str(x),
		"y": str(y),
		"emotion": "blij"
	}
	myJson = json.dumps(data)
	print(f"> {data}")
	return myJson

server_ip = socket.gethostbyname(socket.gethostname())
print("I am %s" % server_ip)

async def hello(websocket, path):
	name = await websocket.recv()
	print(f"< {name}")
	# greeting = f"Hello {name}!"
	# await websocket.send(greeting)
	# print(f"> {greeting}")
	await websocket.send(sendCoords(13, 37))
	time.sleep(1)

start_server = websockets.serve(hello, server_ip, 1337)

asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()
