namespace MediApp.Entities
{
    public class Medicine
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; init; }
        public int Quantity { get; init; }
        public DateTime CreationDate { get; init; } = DateTime.UtcNow;
    }
}
