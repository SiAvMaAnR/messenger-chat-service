using MessengerX.Infrastructure.RabbitMQ;
using Microsoft.AspNetCore.Mvc;

namespace MessengerX.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IRabbitMQService _rabbitMQService;

    public TestController(IRabbitMQService rabbitMQService)
    {
        _rabbitMQService = rabbitMQService;
    }

    [HttpGet("rabbit-mq")]
    public IActionResult TestRabbitMQ()
    {
        _rabbitMQService.SendMessage(
            new
            {
                message = new { content = "content", role = "role" },
                apiKey = new { model = "GigaChat", content = "key" },
                messages = new List<object>()
            }
        );

        return Ok();
    }
}
