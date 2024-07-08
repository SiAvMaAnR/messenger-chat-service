#!/bin/bash

if [ -z "$1" ]; then
  imageName="samarkinivan/chat-service"
else
  imageName="$1"
fi

cd ../../

# dotnet format

# build image from Dockerfile
docker buildx build -t $imageName .

# push to DockerHub
docker push $imageName

# cache clear
docker buildx prune -af
