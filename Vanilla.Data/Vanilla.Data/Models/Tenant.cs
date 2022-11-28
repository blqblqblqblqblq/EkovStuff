using System;
namespace Vanilla.Data.Models
{
    public class Tenant : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
