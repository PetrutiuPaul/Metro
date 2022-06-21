using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly DataBaseContext _context;

        public BasketRepository(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }

        public IQueryable<Basket> Get(int id, CancellationToken cancellationToken)
        {
            return _context.Baskets.Include(b => b.Items)
                .Where(b => b.Id == id);
        }

        public async Task<Basket> Add(Basket basket, CancellationToken cancellationToken)
        {
            _context.Baskets.Add(basket);
            await _context.SaveChangesAsync(cancellationToken);
            return basket;
        }

        public async Task Update(Basket basket, CancellationToken cancellationToken)
        {
            _context.Baskets.Update(basket);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
