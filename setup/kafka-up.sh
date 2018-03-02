docker run -d -p 2181:2181 -p 9092:9092 -e ADVERTISED_HOST=10.0.75.1 -e 9092:9092 --name kafka spotify/kafka
