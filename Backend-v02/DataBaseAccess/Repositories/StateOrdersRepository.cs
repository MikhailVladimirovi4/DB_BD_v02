using Backend_v02.DataBaseAccess.Entities;
using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_v02.DataBaseAccess.Repositories
{
    public class StateOrdersRepository : IStateOrdersRepository
    {
        private readonly DataBaseDbContext _context;

        public StateOrdersRepository(DataBaseDbContext context)
        {
            _context = context;
        }

        public async Task<List<StateOrder>> Get()
        {
            var stateOrderEntities = await _context.StateOrders
                .AsNoTracking()
                .ToListAsync();

            var stateOrder = stateOrderEntities
                .Select(b => StateOrder.Create(b.Id, b.Number, b.Name, b.Year))
                .ToList();

            return stateOrder;
        }

        public async Task<Guid> Create(StateOrder stateOrder)
        {
            StateOrderEntity stateOrderEntity = new StateOrderEntity
            {
                Id = stateOrder.Id,
                Name = stateOrder.Name,
                Year = stateOrder.Year,
            };

            await _context.StateOrders.AddAsync(stateOrderEntity);
            await _context.SaveChangesAsync();

            return stateOrderEntity.Id;
        }

        public async Task<Guid> Update(Guid id, int number, string name, int year)
        {
            await _context.StateOrders
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Number, b => number)
                .SetProperty(b => b.Name, b => name)
                .SetProperty(b => b.Year, b => year));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.StateOrders
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
