namespace Presentation.VMs.Helpers
{
    public class PaginationModelResult<T>
    {
        public ICollection<T> Items { get; set; } = new List<T>();
        public int TotalItems { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
