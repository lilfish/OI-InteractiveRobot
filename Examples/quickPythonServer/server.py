import asyncio
import websockets
import time

print("something")
async def start_server(websocket, path):
    name = await websocket.recv()
    print(f"< {name}")

    greeting = f"Hello {name}!"
    xy = str("960,540")
    time.sleep(5)
    await websocket.send(xy)
    # print(f"> {greeting}")

start_server = websockets.serve(start_server, 'localhost', 8765)

asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()