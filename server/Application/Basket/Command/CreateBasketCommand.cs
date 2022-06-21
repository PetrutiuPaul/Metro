using Application.Interfaces.Repository;
using AutoMapper;
using Contracts.Models;
using Domain.Entities;
using MediatR;

namespace Application.Todos.Command
{
    public class CreateBasketCommand : IRequest<BasketDto>
    {
        public string Customer { get; set; }

        public bool PaysVAT { get; set; }

        public class CreateCommandHandler : IRequestHandler<CreateBasketCommand, BasketDto>
        {
            private readonly IBasketRepository _basketRepository;
            private readonly IMapper _mapper;

            public CreateCommandHandler(IBasketRepository basketRepository, IMapper mapper)
            {
                _basketRepository = basketRepository;
                _mapper = mapper;
            }

            public async Task<BasketDto> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
            {
                var basket = new Basket(request.Customer, request.PaysVAT);
                return _mapper.Map<BasketDto>(await _basketRepository.Add(basket, cancellationToken));
            }
        }
    }
}
