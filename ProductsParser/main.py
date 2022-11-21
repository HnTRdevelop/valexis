import mysql
import xlrd
import os


def main():
    # connection = mysql.connector.connect(user='scott', password='password',
    #                                      host='127.0.0.1',
    #                                      database='employees')

    path = os.path.dirname(os.path.realpath(__file__))
    file = xlrd.open_workbook(f'{path}/tables/test.xls')
    table = file.sheet_by_index(0)
    for row_index in range(table.nrows):
        print(f"{table.row(row_index)}")

    # connection.close()


if __name__ == "__main__":
    main()
