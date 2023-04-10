namespace MemberPlatformCore.Models
{
    public class ProductUnit
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public TimeSpan StartTimeScheduled { get; set; }
        public TimeSpan EndTimeScheduled { get; set; }
        public TimeSpan? StartTimeActual { get; set; }
        public TimeSpan? EndTimeActual { get; set; }
        public int AddressId { get; set; }
        public int ProductUnitStatusId { get; set; }
    }
}
