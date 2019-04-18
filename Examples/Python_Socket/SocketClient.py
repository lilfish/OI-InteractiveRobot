import sys
import socket
import time

def sendCoords( sck, x, y ):
	msg = "[%i,%i]\n" % (x,y)
	sck.send(msg.encode())

# Create a TCP/IP socket
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# Connect the socket to the port on the server given by the caller
# server_address = (sys.argv[1], 10000)
server_address = ("145.93.113.111", 1337)
# print >>sys.stderr, 'connecting to %s port %s' % server_address
sock.connect(server_address)

try:

	# message = 'This is the message.  It will be repeated.'
	# print >>sys.stderr, 'sending "%s"' % message
	for i in range(10):
	    # sock.sendall(message)
		cx = 100 + i
		cy = 100 - i
		# msg = '[' + str(cx) + ','+ str(cy)+']\n'
		# sock.send(msg.encode())
		sendCoords(sock, cx, cy)
		time.sleep(1)

finally:
    sock.close()
