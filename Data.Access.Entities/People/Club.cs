using System.ComponentModel.DataAnnotations;

namespace Data.Access.Entities.People
{
    public class Club : BaseEntity<long>
    {
        [MaxLength(10)]
        public required string Code { get; set; }
        [MaxLength(150)]
        public required string Name { get; set; }
        [MaxLength(150)]
        public required string Address { get; set; }
        [MaxLength(5)]
        public required string Cp { get; set; }
        [MaxLength(150)]
        public required string City { get; set; }
        [MaxLength(150)]
        public required string Province { get; set; }
        [MaxLength(12)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(12)]
        public string Fax { get; set; } = string.Empty;
        [MaxLength(512)]
        public string Observations { get; set; } = string.Empty;

    }
}
