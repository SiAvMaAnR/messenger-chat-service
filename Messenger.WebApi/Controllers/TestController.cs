using MessengerX.Domain.Shared.Models;
using MessengerX.Infrastructure.RabbitMQ;
using Microsoft.AspNetCore.Mvc;

namespace MessengerX.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IRabbitMQProducer _rabbitMQProducer;

    public TestController(IRabbitMQProducer rabbitMQProducer)
    {
        _rabbitMQProducer = rabbitMQProducer;
    }

    [HttpGet("rabbit-mq")]
    public async Task<IActionResult> TestRabbitMQ()
    {
        AIMessage? result = await _rabbitMQProducer.Emit<AIMessage>(
            RMQ.Queue.Ai,
            RMQ.Pattern.CreateMessage,
            new
            {
                message = new { content = "Кто такой цицерон?", role = "user" },
                apiKey = new
                {
                    model = "GigaChat",
                    content = "NzIwYjVhNWQtODFjNC00MzFlLWFhNGEtY2ZkNjMyYWUxZWEwOjBkYTlkOTJmLTQ5ZGItNDNkMS1hOTFjLTFlZmVmMTMxOTE5Ng==",
                },
                temperature = 0.6,
                messages = new List<object>(),
            }
        );

        return Ok(result);
    }
}
