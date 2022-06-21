using Application.Interfaces.Repository;
using MediatR;


namespace Application.Baskets.Command
{
    public class UpdateBasketCommand : IRequest
    {
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public int BasketId { get; set; }

        public bool Close { get; set; }

        public bool Payed { get; set; }

        public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand>
        {
            private readonly IBasketRepository _basketRepository;

            public UpdateBasketCommandHandler(IBasketRepository basketRepository)
            {
                _basketRepository = basketRepository;
            }

            public async Task<Unit> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
            {
                var basket = await _basketRepository.Get(request.BasketId, cancellationToken);
                basket.Close = request.Close;
                basket.Payed = request.Payed;
                await _basketRepository.Update(basket, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
