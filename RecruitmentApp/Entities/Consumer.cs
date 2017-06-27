using System;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentApp.Entities
{
    public class Consumer : IEntityWithGuidId
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Number { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public Guid GetId()
        {
            return Id;
        }
    }
}