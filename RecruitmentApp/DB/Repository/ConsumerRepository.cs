using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecruitmentApp.Entities;

namespace RecruitmentApp.DB.Repository
{
    public interface IConsumerRepository : IBaseRepository<Consumer>
    {
        Task<Consumer> GetById(Guid id);
        Task<bool> DeleteById(Guid id);
    }

    public class ConsumerRepository : BaseRepository<Consumer>, IConsumerRepository
    {
        public ConsumerRepository(ConsumerContext context) : base(context)
        {
        }

        public override Task<bool> Add(Consumer consumer)
        {
            consumer.Id = Guid.NewGuid();
            consumer.Address.ConsumerId = consumer.Id;
            return base.Add(consumer);
        }

        public override IQueryable<Consumer> GetAll()
        {
            return base.GetAll().Include(con => con.Address);
        }
        
        public Task<Consumer> GetById(Guid id)
        {
            return Data.Include(cons => cons.Address).AsNoTracking()
                .FirstOrDefaultAsync(cons => cons.Id.Equals(id));
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var toRemove = await Data.FirstOrDefaultAsync(cons => cons.Id.Equals(id));
            Data.Remove(toRemove);
            return await SaveChangesAsync() > 1;
        }
    }
}