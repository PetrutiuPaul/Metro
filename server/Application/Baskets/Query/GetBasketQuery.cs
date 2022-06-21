using Application.Interfaces.Repository;
using AutoMapper;
using Contracts.Models;
using MediatR;

namespace Application.Todos.Query
{
    public class GetBasketQuery : IRequest<BasketDto>
    {
        public int Id { get; set; }

        public class GetBasketHandler : IRequestHandler<GetBasketQuery, BasketDto>
        {
            private readonly IBasketRepository _basketRepository;
            private readonly IMapper _mapper;

            public GetBasketHandler(IBasketRepository basketRepository, IMapper mapper)
            {
                _basketRepository = basketRepository;
                _mapper = mapper;
            }

            public async Task<BasketDto> Handle(GetBasketQuery request, CancellationToken cancellationToken)
            {
                var basket = await _basketRepository.Get(request.Id, cancellationToken);
                return _mapper.Map<BasketDto>(basket);
            }
        }
    }
}
