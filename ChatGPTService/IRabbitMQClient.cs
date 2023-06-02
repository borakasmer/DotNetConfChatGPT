namespace ChatGPTService
{
    public interface IRabbitMQClient
    {
        public bool PostPhisihnigmail(string channelName, string prompt);
    }
}
