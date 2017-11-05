# myaccountbalanceapi

#### Requirements

* [Visual Studio 2017 + Update 3](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes)
* [.NET SDK 2.0](https://www.microsoft.com/net/download/core)
* [Docker](https://docs.docker.com/docker-for-windows/install/) (Opcional)

#### Setup

* Run the ´./up-kafka-mongodb.sh´ to run Kafka and MongoDB as Docker Containers

#### How to run Bearer Authencation API

1. At `source\BearerAuthAPI` folder run the command: `dotnet run --project BearerAuthAPI.Infrastructure`
2. Navigate to the Kestrel URL and navigate to swagger (eg. http://localhost:15878/swagger).
3. Click on the yellow box and hit 'Try it out!'.
4. Store the Bearer Token. 

#### How to the Consumer API

1. At `source\MyAccountBalanceAPI\MyAccountAPI.Consumer.Infrastructure` edit the appsettings.json with the appropriete connections strings:
```
{
  "MongoDB": {
    "ConnectionString": "mongodb://10.0.75.1:27017",
    "Database": "MyAccountAPIv05"
  },

  "ServiceBus": {
    "ConnectionString": "10.0.75.1:9092",
    "Topic": "MyAccountAPIv05"
  }
}
```
2. At 'source\MyAccountBalanceAPI' folder run the command `dotnet run --project MyAccountAPI.Consumer.Infrastructure`
3. At 'source\MyAccountBalanceAPI' folder run the command `dotnet run --project MyAccountAPI.Producer.Infrastructure`
