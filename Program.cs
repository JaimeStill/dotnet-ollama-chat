using System.Text.Json;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder();
List<ChatMessage> history = [];

builder
    .Services
    .AddChatClient(
        new OllamaChatClient(
            new Uri("http://localhost:11434"),
            "llama3"
        )
    );

IHost app = builder.Build();

IChatClient client = app
    .Services
    .GetRequiredService<IChatClient>();

Console.WriteLine(JsonSerializer.Serialize(client.Metadata));

while (true)
{
    Console.WriteLine();

    Console.WriteLine("User Prompt:");
    string prompt = Console.ReadLine() ?? "What is .NET? Reply in 50 words max.";
    history.Add(new(ChatRole.User, prompt));

    string response = string.Empty;

    Console.WriteLine();
    Console.WriteLine("AI Response:");
    await foreach (StreamingChatCompletionUpdate item in client.CompleteStreamingAsync(history))
    {
        Console.Write(item.Text);
        response += item.Text;
    }

    history.Add(new ChatMessage(ChatRole.Assistant, response));
    Console.WriteLine();
}