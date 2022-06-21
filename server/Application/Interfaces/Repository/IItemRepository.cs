using Domain.Entities;

namespace Application.Interfaces.Repository
{
    public interface IItemRepository
    {
        Task<Item> Add(Item item, CancellationToken cancellationToken);
    }
}
