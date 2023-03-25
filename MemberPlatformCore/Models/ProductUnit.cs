namespace MemberPlatformCore.Models
{
    public class ProductUnit
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public DateTime StartTimeScheduled { get; set; }
        public DateTime EndTimeScheduled { get; set; }
        public DateTime StartTimeActual { get; set; }
        public DateTime EndTimeActual { get; set; }
        public int AddressId { get; set; }
        public int ProductUnitStatusId { get; set; }
    }
}
