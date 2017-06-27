using Microsoft.EntityFrameworkCore;
using RecruitmentApp.Entities;

namespace RecruitmentApp.DB.Repository
{
    public interface IConsumerRepository : IBaseRepository<Consumer>
    {
    }

    public class ConsumerRepository : BaseRepository<Consumer>, IConsumerRepository
    {
        public ConsumerRepository(ConsumerContext context) : base(context)
        {
        }
    }
}