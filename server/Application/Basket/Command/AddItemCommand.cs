using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Todos.Command
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
            private readonly IMapper _mapper;

            public AddItemCommandHandler(IBasketRepository basketRepository, IMapper mapper)
            {
                _basketRepository = basketRepository;
                _mapper = mapper;
            }

            public Task<Unit> Handle(AddItemCommand request, CancellationToken cancellationToken)
            {
                var basket = _basketRepository.Get(request.BasketId, cancellationToken).FirstOrDefault();
                var item = new Item(request.Item, request.Price, request.BasketId);
                basket.Items.Add(item);
                _basketRepository.Update(basket, cancellationToken);
                return Task.FromResult(Unit.Value);
            }
        }
    }
}
