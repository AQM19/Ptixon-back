namespace Data.Access.Entities
{
    public class BaseEntity<T>
    {
        public required T Id { get; set; }
    }
}
