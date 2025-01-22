# run the official ollama container without a volume
sudo docker run -d \
    --gpus all \
    -p 11434:11434 \
    --name ollama \
    ollama/ollama

# pull the latest llama3.2 model
sudo docker exec -it ollama ollama pull llama3.2

# generate a cached image from the running container
sudo docker commit ollama s2va/ollama:llama3.2

# stop the ollama container
sudo docker container stop ollama

# remove the ollama container
sudo docker rm ollama