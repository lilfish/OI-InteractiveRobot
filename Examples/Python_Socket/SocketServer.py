import sys
import socket
import time
import asyncio
import websockets

def sendCoords( sck, x, y ):
	msg = "[%i,%i]\n" % (x,y)
	sck.send(msg.encode())

print("I am %s" % socket.gethostbyname(socket.gethostname()))

async def hello(websocket, path):
    name = await websocket.recv()
    print(f"< {name}")

    greeting = f"Hello {name}!"

    await websocket.send(greeting)
    print(f"> {greeting}")

start_server = websockets.serve(hello, 'localhost', 1337)

asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()
