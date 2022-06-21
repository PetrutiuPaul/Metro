using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataBaseContext _context;

        public ItemRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Item> Add(Item item, CancellationToken cancellationToken)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync(cancellationToken);
            return item;
        }
    }
}
