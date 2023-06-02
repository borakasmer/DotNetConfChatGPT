using RabbitMQ.Client;
using System.Text.Json;

namespace ChatGPTService
{
    public class RabbitMQClient : IRabbitMQClient
    {
        public bool PostPhisihnigmail(string channelName, string prompt)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(channelName, false, false, false, null);

                    var tempData = JsonSerializer.Serialize(prompt);
                    var data = System.Text.Encoding.UTF8.GetBytes(tempData);

                    channel.BasicPublish("", channelName, null, data);
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
    }
}
