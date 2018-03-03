#!/bin/bash
DOCKERPULL=`docker pull ivanpaulovich/castanha:latest`
if [[ $DOCKERPULL != *"Status: Image is up to date for"* || $1 == '/f' ]]; then
        echo "Updating"
        docker stop castanha-backend
        docker rm castanha-backend
        docker run -d -p 8040:80 -e modules__2__properties__ConnectionString=mongodb://10.0.75.1:27017 -e modules__3__properties__BrokerList=10.0.75.1:9092 --name castanha-backend ivanpaulovich/castanha:latest			
else
        echo "Image is already updated"
fi