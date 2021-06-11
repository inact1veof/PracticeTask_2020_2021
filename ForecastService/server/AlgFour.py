from array import *
import pyodbc
import datetime
import numpy as np
from sklearn.linear_model import LinearRegression

hoursInDay = 24
Dates = []
Values =[]
ResultValues =[]
CountOfElements = 0
RmseDates = []
RmseValues =[]

def SeachNumberLong(inputDate):
    result = 0
    counter = 0
    for i in Dates:
        counter+= 1
        if i.strftime('%Y-%m-%d %H') == inputDate.strftime('%Y-%m-%d %H'):
            result = counter
    return result
def SeachNumberShort(inputDate, dates):
    result = 0
    counter = 0
    for i in dates:
        counter += 1
        if i.strftime('%Y-%m-%d') == inputDate.strftime('%Y-%m-%d'):
            result = counter
    return result
def CalculateRMSE(values, count):
    result = 0
    temp = 0
    for i in range(0, count-1):
        temp += ((Values[i]-values[i]) ** 2) ** 0.5
        if i % 24 == 0:
            temp /= 24
            RmseValues.append(temp)
            temp = 0

def forecast(values,count, trainSecondValues, trainRealValues):
    result = 0
    x = np.array(trainRealValues).reshape(-1,1)
    y = np.array(trainSecondValues).reshape(-1,1)
    model = LinearRegression().fit(x, y)
    for i in range(0, count-1):
        ResultValues.append(model.predict([[values[i]]]))
    return result

def main(date, device):
    real_value_id = 0
    dbcon = pyodbc.connect(Trusted_Connection='yes', driver = '{SQL Server}',server = 'DESKTOP-MES4B5O\SQLEXPRESS' , database = 'aspnet-WebApplication1-20210530014617')
    dbconNew = pyodbc.connect(Trusted_Connection='yes', driver = '{SQL Server}',server = 'DESKTOP-MES4B5O\SQLEXPRESS' , database = 'ApiData')
    cursorNew = dbcon.cursor()
    cursor = dbconNew.cursor()
    cursorNew.execute("SELECT Date_Time FROM RealValues WHERE Device_Id = %s" % device)

    for row in cursorNew:
        Dates.append(row[0])
    cursorNew.execute("SELECT Value FROM RealValues WHERE Device_Id = %s" % device)
    for row in cursorNew:
        Values.append(float(row[0]))
    SecondValues = []
    trainRealValues = []
    trainSecondValues = []
    cursor.execute("SELECT Value FROM Algoritm_Results WHERE DeviceId = %s AND Algoritm_Id = '3'" % device)
    for row in cursor:
        SecondValues.append(float(row[0]))
    for i in range(0, 1000):
        trainSecondValues.append(SecondValues[i])
        trainRealValues.append(Values[i])

    CountOfElements = len(Values)
    Values.pop()
    forecast(Values, CountOfElements, trainSecondValues, trainRealValues)
    cursor = dbconNew.cursor()
    cursorNew = dbcon.cursor()
    TempArray = []
    for i in ResultValues:
        TempArray.append(i[0,0])
    for i in range(0, CountOfElements-1):
        ResultValues[i] = TempArray[i]

    for i in range(0, CountOfElements-1):
        cursor.execute("INSERT Algoritm_Results VALUES(%s, '%s', %s, %s)" % ('4', Dates[i].strftime("%d.%m.%Y %H:%M:%S"), ResultValues[i], device))
    for i in range(0, CountOfElements-1):
        if i % 24 == 0:
            RmseDates.append(Dates[i])
    CalculateRMSE(ResultValues, CountOfElements)

    for i in range(0, len(RmseDates)):
        cursor.execute("INSERT Rmse_Values VALUES('%s', %s, %s, %s)" % (RmseDates[i].strftime("%d.%m.%Y %H:%M:%S"), RmseValues[i], '4', device))

    dateTime = date
    numberDateForExportLong = SeachNumberLong(dateTime)
    numberDateForExportShort = SeachNumberShort(dateTime, RmseDates)

    dbcon.commit()
    dbconNew.commit()
    cursorNew = dbcon.cursor()
    cursor = dbconNew.cursor()
    cursor.execute("SELECT Id FROM Algoritm_Results WHERE DateTime = '%s' AND Algoritm_id = '4'" % Dates[
        numberDateForExportLong].strftime("%d.%m.%Y %H:%M:%S"))
    for row in cursor:
        value_id = row[0] - 1
    cursor.execute(
        "SELECT Id FROM Rmse_Values WHERE Date = '%s' AND AlgId = '4'" % RmseDates[numberDateForExportShort].strftime(
            "%d.%m.%Y %H:%M:%S"))
    for row in cursor:
        rmse_value_id = row[0] - 2
    cursorNew.execute("SELECT Id FROM RealValues WHERE Date_Time = '%s'" % Dates[numberDateForExportLong - 1].strftime("%Y-%d-%m %H:%M:%S"))
    for row in cursorNew:
        real_value_id = row[0]-1
    resultStr = f"INSERT Forecasts VALUES(%s, '%s', %s, %s, %s, %s)" % ('4', dateTime.strftime("%d.%m.%Y %H:%M:%S"), value_id, real_value_id, rmse_value_id, device)
    cursor.execute(resultStr)
    dbcon.commit()
    dbconNew.commit()
    TempArray.clear()
    Dates.clear()
    Values.clear()
    ResultValues.clear()
    RmseDates.clear()
    RmseValues.clear()
    print(f"Выполнен прогноз алгоритмом 4 для данных")
