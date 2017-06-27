using System;

namespace RecruitmentApp.Entities
{
    public class Address :IEntityWithIntId
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public Guid ConsumerId { get; set; }
        public virtual Consumer Consumer { get; set; }

        public int GetId()
        {
            return Id;
        }

        public void Copy(Address entityAddress)
        {
            Street = entityAddress.Street;
            City = entityAddress.City;
        }
    }
}