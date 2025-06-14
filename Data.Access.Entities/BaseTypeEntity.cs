using System.ComponentModel.DataAnnotations;

namespace Data.Access.Entities
{
    public class BaseTypeEntity<T> : BaseEntity<T>
    {
        [MaxLength(30)]
        public required string Nemonic { get; set; }
        [MaxLength(256)]
        public string? Description { get; set; }
    }
}
