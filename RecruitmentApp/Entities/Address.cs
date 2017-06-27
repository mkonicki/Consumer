using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Entities
{
    public class Address :IEntityWithIntId
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public Guid ConcumerId { get; set; }
        public virtual Consumer Consumer { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}