#!/bin/bash

DOCKER_COMPOSE_FILE="docker-compose.yaml"

echo "Step 1: Running Docker Compose..."
docker-compose -f $DOCKER_COMPOSE_FILE up -d --build

container_name=elympics-api
max_retries=${2:-20}
retry_interval=2

retries=0

# while [ $retries -lt $max_retries ]; do
#     healthy=$(docker inspect --format='{{.State.Status}}' $container_name 2>/dev/null)

#     if [ "$healthy" == "running" ]; then
#         echo "Container $container_name is healthy."
#         docker inspect $container_name
#         dotnet test ./Elympics.IntegrationTest/Elympics.IntegrationTest.csproj

#         echo "Step 4: Stopping and removing Docker containers..."
#         docker-compose -f $DOCKER_COMPOSE_FILE down

#         echo "Finished!"
#         exit 0
#     fi

#     retries=$((retries+1))
#     echo "Waiting for container $container_name to be healthy (retry $retries of $max_retries)..."
#     sleep $retry_interval
# done

docker run -d -p 5000:5000 --restart=always --name localregistry registry:2

docker tag elympics-api localhost:5000/elympics-api
docker tag elympics-random localhost:5000/elympics-random

docker push localhost:5000/elympics-api
docker push localhost:5000/elympics-random

helm install elympics-api-release ./k8s/elympics-api/

curl -X POST http://localhost:8082/random-number

helm delete elympics-api-release