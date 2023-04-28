namespace MemberPlatformCore.Models
{
    public class Person
    {
        public int Id { get; set; }
        public bool PrivacyApproval { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }

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
        public int? ParentId { get; set; }
        public int AddressTypeId { get; set; }
        public int AddressId { get; set; }
        public string FullName { get { return FirstName + ' ' + LastName; } }
    }
}
