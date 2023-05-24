namespace Core.Entities.PurchaseOrder
{
    public class Address
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Department { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        public Address() { }

        public Address(string? street, string? city, string? department, string? postalCode, string? country)
        {
            Street = street;
            City = city;
            Department = department;
            PostalCode = postalCode;
            Country = country;
        }
    }
}