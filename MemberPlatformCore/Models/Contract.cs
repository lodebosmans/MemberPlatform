namespace MemberPlatformCore.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ContractTypeId { get; set; }
    }
}
