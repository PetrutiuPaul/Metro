using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts.Models;
using MediatR;

namespace Application.Todos.Query
{
    public class GetBasketQuery : IRequest<IQueryable<BasketDto>>
    {
        public int Id { get; set; }

        public class GetBasketHandler : IRequestHandler<GetBasketQuery, IQueryable<BasketDto>>
        {
            private readonly IBasketRepository _basketRepository;
            private readonly IMapper _mapper;

            public GetBasketHandler(IBasketRepository basketRepository, IMapper mapper)
            {
                _basketRepository = basketRepository;
                _mapper = mapper;
            }

            public Task<IQueryable<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
            {
                var basket = _basketRepository.Get(request.Id, cancellationToken);
                return Task.FromResult(basket.ProjectTo<BasketDto>(_mapper.ConfigurationProvider));
            }
        }
    }
}
