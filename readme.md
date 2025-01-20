# .NET LLM Integration with Ollama and Microsoft.Extensions.AI

> [!IMPORTANT]
> If running with NVIDIA GPU on Linux, be sure to install the [NVIDIA Container Toolkit](https://docs.nvidia.com/datacenter/cloud-native/container-toolkit/latest/install-guide.html).
>
> You'll also want to be sure to have [Docker Engine](https://docs.docker.com/engine/install/) installed rather than [Docker Desktop](https://www.docker.com/products/docker-desktop/).
>
> See also [Docker Engine - Resource Constraints: Access an NVIDIA GPU](https://docs.docker.com/engine/containers/resource_constraints/#gpu).

1. Ensure that the ollama container is running and has pulled in the **`llama3`** LLM.

    > [!TIP]
    > This is provided as the [**`start-ollama.bash`**](./start-ollama.bash) script.

    ```sh
    # Run the ollama container
    sudo docker run -d \
        --gpus all \
        -v ollama_data:/root/.ollama \
        -p 11434:11434 \
        --name ollama \
        ollama/ollama

    # Pull the llama3.1 model
    sudo docker exec -it ollama ollama pull llama3
    ```

2. Run the .NET app:

    ```sh
    dotnet run
    ```

3. Sample:

    > **Prompt:**  
    > Provide a ~100 word analysis of the movie A Clockwork Orange.
    >  
    > **AI Response:**  
    > A Clockwork Orange, directed by Stanley Kubrick in 1971, is a dystopian masterpiece that explores themes of free will, morality, and the dangers of societal conditioning. The film follows Alex, a charismatic and violent teenager who leads a gang of droogs (friends) through a nightmarish world where crime and brutality are rampant. After being imprisoned for murder, Alex is subjected to Ludovico technique, a government-backed aversion therapy designed to "cure" him of his violent tendencies. As Alex navigates this treatment, the film raises questions about whether it's possible to erase one's innate nature and whether such attempts can lead to further moral decay.