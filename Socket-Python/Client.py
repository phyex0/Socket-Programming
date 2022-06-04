import socket


def client_program():
	HOST = '127.0.0.1'
	PORT = 9601
	with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
		s.connect((HOST, PORT))
		print(s.send(f"{input()} <EOF>".encode()))
		s.close()


if __name__ == '__main__':
	while True:
		client_program()
