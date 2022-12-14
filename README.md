# MassTransitShopping

## 1. Common Library
All the events are maintained in ShoppingEvents project so that other service can use them from this library. 

## 2. Setup RabbitMQ, Redis, and MongoDb
Run the docker compose up command to create our infrastructure.

```
docker compose up --build
```

## 3. Run the OrderService
The OrderService has an Api method to check order. That does nothing at the moment other than logging the requested order id, publishing an event of type ```CheckOrder``` with that order id, and returning ```OK```.
Please run this from your IDE or from the terminal by using ```dotnet run```.


## 3. Run the ProcessingService
The ProcessingService is a hosted service that consumes the ```CheckOrder``` messages from the queue and logs the consumed order id. 
Please run this from your IDE or from the terminal by using ```dotnet run```.

## 4. See in action
From the swagger Api, please enter a guid and check the console of both services while they are running.
