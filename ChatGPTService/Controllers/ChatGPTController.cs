using Microsoft.AspNetCore.Mvc;

namespace ChatGPTService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatGPTController : ControllerBase
    {
        public IRabbitMQClient _rabbitmQClient;
        public ChatGPTController(IRabbitMQClient rabbitmQClient)
        {
            _rabbitmQClient = rabbitmQClient;
        }

        [HttpPost(Name = "PostPhishingMail")]
        public bool Post(string channelName, string prompt)
        {
            return _rabbitmQClient.PostPhisihnigmail(channelName, prompt);
        }
    }
}