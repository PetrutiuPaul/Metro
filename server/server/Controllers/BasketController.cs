using Application.Todos.Command;
using Application.Todos.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using server.Atributes;
using System.Threading.Tasks;

namespace server.Controllers
{
    [ApiController]
    [Route("api/baskets")]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket([FromBody] CreateBasketCommand command)
        {
            var basket = await _mediator.Send(command);
            return Ok(basket);
        }

        [HttpGet]
        [Cache(5000)]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var basket = await _mediator.Send(new GetBasketQuery { Id = id });
            return Ok(basket);
        }

        [HttpPatch]
        [Route("{id}/article-line")]
        public async Task<IActionResult> AddArticleLine(int id, [FromBody] AddItemCommand command)
        {
            command.BasketId = id;
            await _mediator.Send(command);
            return Ok();
        }
    }
}
