# Run the ollama container
sudo docker run -d \
    --gpus all \
    -v ollama_data:/root/.ollama \
    -p 11434:11434 \
    --name ollama \
    ollama/ollama

# Pull the llama3 model
sudo docker exec -it ollama ollama pull llama3