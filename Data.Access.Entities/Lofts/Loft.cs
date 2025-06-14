using Data.Access.Entities.People;

namespace Data.Access.Entities.Lofts
{
    public class Loft : BaseEntity<long>
    {
        public required Member Member { get; set; }
        public required float Latitude { get; set; }
        public required float Longitude { get; set; }
    }
}
