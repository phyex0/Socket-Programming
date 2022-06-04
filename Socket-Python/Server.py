import socket


def server_program():
	HOST = '127.0.0.1'
	PORT = 9601

	with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
		s.bind((HOST, PORT))
		s.listen()
		while True:

			conn, addr = s.accept()
			with conn:
				print('Connected by', addr)
				while True:
					data = conn.recv(1024)
					if not data:
						break
					print(data.decode())


if __name__ == '__main__':
	server_program()
