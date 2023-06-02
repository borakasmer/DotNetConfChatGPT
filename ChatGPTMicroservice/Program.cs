// See https://aka.ms/new-console-template for more information

using ChatGPTMicroservice;
using System.Text.Json;

using (RabbitMQClient rabbitMQClient = new())
using (ChatGPTClient chatGPTClient = new())
{

    var consumer = rabbitMQClient.GetConsumer("PhishingMail");
    consumer.Received += (model, ea) =>
    {
        var tempData = ea.Body.ToArray();
        var data = System.Text.Encoding.UTF8.GetString(tempData);

        var prompt = JsonSerializer.Deserialize<string>(data);
        var phishingMail = chatGPTClient.GetPhishingMail(prompt);
        Console.WriteLine(phishingMail);    
    };
    Console.WriteLine("press any key to Exit");
    Console.ReadLine();
}
