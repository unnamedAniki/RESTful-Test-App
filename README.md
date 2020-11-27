# RESTful-Test-App
Выполнение тестового задания 

Тестировал API с помощью Postman

Ниже указаны следующие тесты:
POSTRequest1 - Попытка снятия средст, которые превышают остаток на счете
http://localhost:7000/api/Bank?UserId=d783b1d3-27eb-4106-9013-ae62533860e9&TransactionTime=2001-09-11&Amount=-1000000&Notes=Cнятие 1000000 гривен

POSTResults1
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.6.1",
    "title": "An error occured while processing your request.",
    "status": 500,
    "detail": "Снимаемая сумма транзакциии должна быть меньше или равна остатку на счете пользователя",
    "traceId": "|30db7833-4ef26a752852fcca."
}

POSTRequest2 - Добавление транзакции пользователю под указанным Id в указанное время
http://localhost:7000/api/Bank/?Amount=-1000&TransactionTime=2019-12-25&Notes=Снятие 1000 гривен&UserId=881035c3-9ac2-4c77-a943-7dcd26a5da30

POSTResult2
{
    "transactionsId": 6,
    "userId": "881035c3-9ac2-4c77-a943-7dcd26a5da30",
    "time": "2019-12-25T00:00:00",
    "notes": "Снятие 1000 гривен",
    "amount": -1000,
    "accounts": null
}

PUTRequest1 - Проверка истории транзакции пользователя с указанным Id в указанный период
http://localhost:7000/api/Bank?UserId=d783b1d3-27eb-4106-9013-ae62533860e9&From=2001-09-11&To=2020-12-11

PUTResult1
[
    {
        "transactionsId": 1,
        "userId": "d783b1d3-27eb-4106-9013-ae62533860e9",
        "time": "2020-11-27T03:22:38.6918158",
        "notes": "Зачисление 100 гривен",
        "amount": 100.0,
        "accounts": null
    },
    {
        "transactionsId": 2,
        "userId": "d783b1d3-27eb-4106-9013-ae62533860e9",
        "time": "2020-11-27T03:38:29.729538",
        "notes": "Зачисление 100 гривен",
        "amount": 100.0,
        "accounts": null
    },
    {
        "transactionsId": 3,
        "userId": "d783b1d3-27eb-4106-9013-ae62533860e9",
        "time": "2020-11-27T03:41:08.4713125",
        "notes": "Зачисление 100 гривен",
        "amount": 100.0,
        "accounts": null
    },
    {
        "transactionsId": 4,
        "userId": "d783b1d3-27eb-4106-9013-ae62533860e9",
        "time": "2020-11-27T03:47:38.6914624",
        "notes": "Начисление 100 гривен",
        "amount": 100.0,
        "accounts": null
    }
]

PUTRequest2 - Попытка просмотра истории транзакции пользователя с указанным Id в период неактивности
http://localhost:7000/api/Bank?UserId=d783b1d3-27eb-4106-9013-ae62533860e9&From=2001-09-11&To=2019-12-11

PUTResult2
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
    "title": "Not Found",
    "status": 404,
    "traceId": "|30db783b-4ef26a752852fcca."
}

PUTRequest3 - Вывод статистики за указанный день
http://localhost:7000/api/Bank/2019-12-27

PUTResult
[
    {
        "name": "d783b1d3-27eb-4106-9013-ae62533860e9",
        "count": 4
    },
    {
        "name": "881035c3-9ac2-4c77-a943-7dcd26a5da30",
        "count": 1
    }
]

GETRequest1 - Вывод остатка счета для пользователя с указанным Id
http://localhost:7000/api/Bank/d783b1d3-27eb-4106-9013-ae62533860e9

GETResult
[
    {
        "userId": "d783b1d3-27eb-4106-9013-ae62533860e9",
        "balance": 100400.0,
        "transactions": []
    }
]
