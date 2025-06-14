using System.ComponentModel.DataAnnotations;

namespace Data.Access.Entities.People
{
    public class Member : BaseEntity<long>
    {
        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(50)]
        public required string Surname { get; set; }
        [MaxLength(150)]
        public required string Address { get; set; }
        [MaxLength(5)]
        public required string Cp { get; set; }
        [MaxLength(150)]
        public required string City { get; set; }
        [MaxLength(150)]
        public required string Province { get; set; }
        public required Club Club { get; set; }
        public required Category Category { get; set; }
        public required DateTimeOffset MemberFrom { get; set; } = DateTimeOffset.UtcNow;
        [MaxLength(512)]
        public string? Observations { get; set; }
    }
}
