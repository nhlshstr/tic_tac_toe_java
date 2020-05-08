#!/usr/bin/env bash
# Executes docker container with tic-tac-toe

docker build -t my-java-app .
docker run -it --rm --name my-running-app my-java-app
