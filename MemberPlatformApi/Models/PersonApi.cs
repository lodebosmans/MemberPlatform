namespace MemberPlatformApi.Models
{
    public class PersonApi
    {
        public int Id { get; set; }
        public bool PrivacyApproval { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Box { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string IdentityNumber { get; set; }
        public string InsuranceCompany { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public int AddressTypeId { get; set; }
        public int AddressId { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Token { get; set; }
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}
