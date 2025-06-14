namespace Data.Access.Entities.Lofts
{
    public class PigeonLoft
    {
        public required Pigeon Pigeon { get; set; }
        public required Loft Loft { get; set; }
        public required DateTimeOffset EntranceAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? ExitAt { get; set; }
    }
}
