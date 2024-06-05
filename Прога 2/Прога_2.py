"""""""""
example products.txt
������,1,01-03-2022 17:30, 02-03-2022 17:30,�1730
�������,2,03-03-2022 6:30, 07-03-2022 17:30,�630
������,3,03-03-2022 6:30, 04-03-2022 6:30,�630
"""""""""
import datetime


def ClearConsole():
    print('\n' * 150)


def OutRed(text):
    print("\033[31m {}".format(text), end="|")


def CheckExpired(product):
    date = product[3].split(' ')[1].split("-")
    time = product[3].split(' ')[2].split(":")
    todayDate = datetime.datetime.today()
    productDate = datetime.datetime(int(date[2]), int(date[1]), int(date[0]), int(time[0]), int(time[1]))
    if int((productDate - todayDate).days) < 0:
        return True
    return False


def PrintMenu():
    print("1) �������� ���� ���������")
    print("2) �������� ���������")
    print("3) ���������� ��������")
    print("4) �������� ��������")
    print("5) ����� ������� �� �������")
    print("6) �����")


def PrintProductList(headers, data):
    nameSpace = 15
    idSpace = 3
    prodSpace = 19
    expiredSpace = 17
    shelfSpace = 5
    print(headers[0] + ' ' * (nameSpace - len(headers[0])), end="|")
    print(headers[1] + ' ' * (idSpace - len(headers[1])), end="|")
    print(headers[2] + ' ' * (prodSpace - len(headers[2])), end="|")
    print(headers[3] + ' ' * (expiredSpace - len(headers[3])), end="|")
    print(headers[4] + ' ' * (shelfSpace - len(headers[4])), end="|")
    print()
    for product in data:
        if CheckExpired(product):

            print("\033[31m" + product[0] + ' ' * (nameSpace - len(product[0])), end="|")
            print("\033[31m" + product[1] + ' ' * (idSpace - len(product[1])), end="|")
            print("\033[31m" + product[2] + ' ' * (prodSpace - len(product[2])), end="|")
            print("\033[31m" + product[3] + ' ' * (expiredSpace - len(product[3])), end="|")
            print("\033[31m" + product[4] + ' ' * (shelfSpace - len(product[4])), end="|")
            print("\033[0m", end="")
            print()
        else:
            print(product[0] + ' ' * (nameSpace - len(product[0])), end="|")
            print(product[1] + ' ' * (idSpace - len(product[1])), end="|")
            print(product[2] + ' ' * (prodSpace - len(product[2])), end="|")
            print(product[3] + ' ' * (expiredSpace - len(product[3])), end="|")
            print(product[4] + ' ' * (shelfSpace - len(product[4])), end="|")
            print()


def updateFile(productList):
    productsFile = open("products.txt", 'w')
    for product in productList:
        productsFile.write(','.join(product))
        productsFile.write('\n')


def PrintExpiredProductList(headers, data):
    nameSpace = 15
    idSpace = 3
    prodSpace = 19
    expiredSpace = 17
    shelfSpace = 5
    print(headers[0] + ' ' * (nameSpace - len(headers[0])), end="|")
    print(headers[1] + ' ' * (idSpace - len(headers[1])), end="|")
    print(headers[2] + ' ' * (prodSpace - len(headers[2])), end="|")
    print(headers[3] + ' ' * (expiredSpace - len(headers[3])), end="|")
    print(headers[4] + ' ' * (shelfSpace - len(headers[4])), end="|")
    print()
    for product in data:
        if CheckExpired(product):
            print("\033[31m" + product[0] + ' ' * (nameSpace - len(product[0])), end="|")
            print("\033[31m" + product[1] + ' ' * (idSpace - len(product[1])), end="|")
            print("\033[31m" + product[2] + ' ' * (prodSpace - len(product[2])), end="|")
            print("\033[31m" + product[3] + ' ' * (expiredSpace - len(product[3])), end="|")
            print("\033[31m" + product[4] + ' ' * (shelfSpace - len(product[4])), end="|")
            print("\033[0m", end="")
            print()



def AddProduct():
    name = input("������� �������� ������:")
    id = input("������� id ������:")
    prodTime = input("������� ����� ������������ ������: ")
    expiredTime = input("������� ���� �������� ������: ")
    shelf = name[0] + ''.join(prodTime.split()[1].split(':'))
    return [name, id, prodTime, expiredTime, shelf]


def DeleteProduct(productList):
    id = input("������� id ������, ������� ����� �������: ")
    for i in range(len(productList)):
        if productList[i][1] == id:
            productList.pop(i)
            break


def GetProduct(products):
    minDay = 9999999999
    prod = []
    for product in products:
        if CheckExpired(product):
            print("������� ������� " + product[0] + ' ' + product[1])
            break
    else:
        for product in products:
            date = product[3].split(' ')[1].split("-")
            time = product[3].split(' ')[2].split(":")
            todayDate = datetime.datetime.today()
            productDate = datetime.datetime(int(date[2]), int(date[1]), int(date[0]), int(time[0]), int(time[1]))
            if int((productDate - todayDate).days) < minDay:
                minDay = int((productDate - todayDate).days)
                prod = product
    print("������� ������� " + prod[0] + ' ' + prod[1])


tableHeaders = [
    "������������",
    "id",
    "����� ������������",
    "������� ��",
    "�����"
]
tableProducts = []
try:
    productsFile = open("products.txt", 'r')
    for line in productsFile:
        productInfo = line.strip().split(',')
        name = productInfo[0]
        id = productInfo[1]
        prodTime = productInfo[2]
        expiredTime = productInfo[3]
        shelf = productInfo[4]
        tableProducts.append([name, id, prodTime, expiredTime, shelf])
    productsFile.close()
except BaseException:
    productsFile = open("products.txt", 'w')
    productsFile.close()
CheckExpired(tableProducts[0])
while True:
    PrintMenu()
    case = int(input("������� ����� ��������: "))
    if case == 1:
        ClearConsole()
        PrintProductList(tableHeaders, tableProducts)
    elif case == 2:
        ClearConsole()
        PrintExpiredProductList(tableHeaders, tableProducts)
    elif case == 3:
        ClearConsole()
        tableProducts.append(AddProduct())
        updateFile(tableProducts)
    elif case == 4:
        ClearConsole()
        DeleteProduct(tableProducts)
        updateFile(tableProducts)
    elif case == 5:
        ClearConsole()
        GetProduct(tableProducts)
    elif case == 6:
        print("����� �� ���������")
        break
productsFile.close()

