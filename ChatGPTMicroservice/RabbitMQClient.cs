using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTMicroservice
{
    public class RabbitMQClient:IDisposable 
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public EventingBasicConsumer GetConsumer(string channelName)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();            

            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(channelName, true, consumer);

            return consumer;
        }
    }
}