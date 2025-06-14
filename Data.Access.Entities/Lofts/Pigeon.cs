using System.ComponentModel.DataAnnotations;

namespace Data.Access.Entities.Lofts
{
    public class Pigeon : BaseEntity<long>
    {
        [MaxLength(8)]
        public required string Ring { get; set; }
        public Pigeon? Father { get; set; }
        public Pigeon? Mother { get; set; }
        public int Points { get; set; } = 0;
    }
}
