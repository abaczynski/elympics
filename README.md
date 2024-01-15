# elympics - recruitment task

Tested on windows 11

## Prerequisites
docker installed and running with kubernetes enabled

helm installed

Docker version 24.0.7, build afdd53b
Helm v3.13.3
Kubernetes v1.28.2

## Installation

```bash
# Example installation steps

cd elympics

bash ./pipeline.sh

    - build project
    - run docker-compose
    - execute integration tests
    - run local docker image registry
    - build release and deploy to kubernetes cluster
    - run e2e test
    - destroy release
    
docker-compose up
    - run application with all dependencies