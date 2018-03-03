#!/bin/bash
DOCKERPULL=`docker pull ivanpaulovich/castanha:latest`
if [[ $DOCKERPULL != *"Status: Image is up to date for"* || $1 == '/f' ]]; then
        echo "Updating"
        docker stop castanha-backend
        docker rm castanha-backend
        docker run -d -p 8040:80 -e modules__2__properties__ConnectionString=mongodb://172.17.0.1:27017 -e modules__3__properties__BrokerList=192.168.0.4:9092 --na$
else
        echo "Image is already updated"
fi