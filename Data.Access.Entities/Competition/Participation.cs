using Data.Access.Entities.Lofts;

namespace Data.Access.Entities.Competition
{
    public class Participation : BaseEntity<long>
    {
        public required Contest Contest { get; set; }
        public required Pigeon Pigeon { get; set; }
        public required DateTimeOffset ArrivalAt { get; set; } = DateTimeOffset.UtcNow;
        public required float Distance { get; set; } = 0; // En metros para pasar a km en conversión
        public required float AverageSpeed { get; set; } = 0; // En metros por segundo para pasar a km/h en conversión
    }
}
