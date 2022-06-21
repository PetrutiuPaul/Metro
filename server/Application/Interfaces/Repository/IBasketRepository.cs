﻿using Domain.Entities;

namespace Application.Interfaces.Repository
{
    public interface IBasketRepository
    {
        IQueryable<Basket> Get(int id, CancellationToken cancellationToken);

        Task<Basket> Add(Basket basket, CancellationToken cancellationToken);

        Task Update(Basket basket, CancellationToken cancellationToken);
    }
}
