using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;


namespace Application.Basket.Command
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
            private readonly IMapper _mapper;

            public UpdateBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper)
            {
                _basketRepository = basketRepository;
                _mapper = mapper;
            }
            
            public Task<Unit> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
            {
                return Unit.Task;
            }
        }
    }
}
