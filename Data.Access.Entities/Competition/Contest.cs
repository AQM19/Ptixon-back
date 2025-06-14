using System.ComponentModel.DataAnnotations;

namespace Data.Access.Entities.Competition
{
    public class Contest : BaseEntity<long>
    {
        [MaxLength(150)]
        public required string Name { get; set; }
        public required Modality Modality { get; set; }
        public required float Latitude { get; set; }
        public required float Longitude { get; set; }
        public required DateTimeOffset ReleaseAt { get; set; }
        public required DateTimeOffset ClockStartAt { get; set; }
        public required ContestType ContestType { get; set; }
        public required int NumberTotalPigeons { get; set; } = 0;
        public required int NumberScoringPigeons { get; set; } = 0;
        // Estas tres no se para qué son
        public int? Distance { get; set; } = null;
        public int? Coefficient { get; set; } = null;
        public int? Percentage { get; set; } = null;
    }
}
