import socket
import pyodbc
import datetime
import AlgOne
import AlgTwo
import AlgThree
import AlgFour
import AlgFive
import subprocess

print("Подключение к базе данных")
try:
    dbcon = pyodbc.connect(Trusted_Connection='yes', driver = '{SQL Server}',server = 'DESKTOP-MES4B5O\SQLEXPRESS' , database = 'aspnet-WebApplication1-20210530014617')
    print("Подключение к базе данных успешно")
except:
    print("Подключение к базе данных не удалось")

# Задаем адрес сервера
SERVER_ADDRESS = ('127.0.0.1', 8686)

# Настраиваем сокет
server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_socket.bind(SERVER_ADDRESS)
server_socket.listen(10)
print('Сервер запущен, ожидаются подключения test_string')

# Слушаем запросы
while True:
    connection, address = server_socket.accept()
    print("Новое подключение клиента {address}".format(address=address))
    connection.send(bytes("Запрос на прогноз принят в обработку", encoding='UTF-16'))
    data = connection.recv(1024)
    print("Новый запрос от клиента: " + str(data, encoding='UTF-16'))
    print("Обработка запроса: " + " | " + str(data, encoding='UTF-16') + " | ")
    parameters = str(data, encoding='UTF-16')
    values = parameters.split(',')
    dateValues = values[0].split('.')
    timeValues = values[1].split(':')
    date = datetime.datetime(int(dateValues[2]), int(dateValues[1]), int(dateValues[0]), int(timeValues[0]), 0, 0)
    DeviceId = values[2]
    dateTime = date
    AlgOne.main(dateTime, DeviceId)
    AlgTwo.main(dateTime, DeviceId)
    AlgThree.main(dateTime, DeviceId)
    AlgFour.main(dateTime, DeviceId)
    AlgFive.main(dateTime, DeviceId)
    print("Прогнозы выполнены, обновите страницу клиента")
    print("Ожидание новых подключений…")
