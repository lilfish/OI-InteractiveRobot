# # import asyncio
# # import websockets

# # async def handle_message(message):
# #     print(message)

# # async def consumer_handler(websocket, path):
# #     while True:
# #         message = await websocket.recv()
# #         await handle_message(message)

# # start_server = websockets.serve(consumer_handler, 'localhost', 8765)

# # asyncio.get_event_loop().run_until_complete(start_server)
# # asyncio.get_event_loop().run_forever()

# import os
# import asyncio
# import websockets


# class Server:

#     def get_port(self):
#         return os.getenv('WS_PORT', '8765')

#     def get_host(self):
#         return os.getenv('WS_HOST', 'localhost')


#     def start(self):
#         return websockets.serve(self.handler, self.get_host(), self.get_port())

#     async def handler(self, websocket, path):
#       async for message in websocket:
#         print('server received :', message)
#         await websocket.send(message)

# if __name__ == '__main__':
#   ws = Server()
#   asyncio.get_event_loop().run_until_complete(ws.start())
#   asyncio.get_event_loop().run_forever()

# DE CODE HIERONDER WERKT WEL OPEENS! :O
import asyncio
import websockets

print("something")
async def hello(websocket, path):
    name = await websocket.recv()
    print(f"< {name}")

    greeting = f"Hello {name}!"

    await websocket.send(greeting)
    print(f"> {greeting}")

start_server = websockets.serve(hello, 'localhost', 8765)

asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()