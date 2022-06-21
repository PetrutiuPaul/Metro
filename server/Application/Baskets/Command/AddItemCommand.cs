using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Baskets.Command
{
    public class AddItemCommand : IRequest
    {
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public int BasketId { get; set; }

        public string Item { get; set; }

        public decimal Price { get; set; }

        public class AddItemCommandHandler : IRequestHandler<AddItemCommand>
        {
            private readonly IBasketRepository _basketRepository;

            public AddItemCommandHandler(IBasketRepository basketRepository)
            {
                _basketRepository = basketRepository;
            }

            public async Task<Unit> Handle(AddItemCommand request, CancellationToken cancellationToken)
            {
                var basket = await _basketRepository.Get(request.BasketId, cancellationToken);
                var item = new Item(request.Item, request.Price, request.BasketId);
                basket.Items.Add(item);
                await _basketRepository.Update(basket, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
