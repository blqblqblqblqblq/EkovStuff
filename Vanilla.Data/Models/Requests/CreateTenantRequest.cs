namespace Models.Requests
{
    public class CreateTenantRequest
    {
        public string Name { get; set; }
        public string OrganisationType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Locality { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
