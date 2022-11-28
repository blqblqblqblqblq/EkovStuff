using Models.Requests;
using Services.Mapperts;

namespace Services.Tests.Mappers
{
    public class EntityMaperTests
    {
        Guid tenantId = Guid.NewGuid();

        [Fact]
        public void ToTenantEntity_SetsturnCorrectData()
        {
            var request = new CreateTenantRequest()
            {
                Name = "name"
            };
            var result = request.ToTenantEntity();

            Assert.Equal(request.Name, result.Name);
        }

        [Fact]
        public void ToLegalEntity_SetsCorrectData()
        {
            var request = new CreateTenantRequest()
            {
                Name = "Mariscos Recio",
                Address1 = "Mirador de Montepinar",
                Address2 = "Mirador de Montepinar Fish Store",
                Country = "Spain",
                Email = "mariscos_recio@gmail.com",
                Locality = "Madrid Río",
                OrganisationType = "Company",
                Phone = "1234567890",
                PostCode = "1234"
            };

            var result = request.ToLegalEntity(tenantId);

            Assert.Equal(tenantId, result.TenantId);
            Assert.Equal(request.Address1, result.Addresses.First().Line1);
            Assert.Equal(request.Address2, result.Addresses.First().Line2);
            Assert.Equal(request.Country, result.Addresses.First().Country);
            Assert.Equal(request.Locality, result.Addresses.First().Locality);
            Assert.Equal(request.Email, result.EmailAddresses.First().Email);
            Assert.Equal(request.OrganisationType, result.LegalEntityType.ToString());
            Assert.Equal(request.Phone, result.PhoneNumbers.First().Phone);
            Assert.Equal(request.PostCode, result.Addresses.First().PostCode);
        }

        [Fact]
        public void ToMembershipGroup_SetsCorrectData()
        {
            var request = new CreateMembershipGroupRequest()
            {
                Description = "description",
                FeeAmount = 100,
                FeeType = "NoFeeRequired",
                GroupName = "GroupName",
                TenantId = tenantId
            };

            var result = request.ToMembershipGroup();

            Assert.Equal(request.Description, result.Description);
            Assert.Equal(request.FeeAmount, result.FeeAmount);
            Assert.Equal(request.FeeType, result.FeeType.ToString());
            Assert.Equal(request.GroupName, result.GroupName);
            Assert.Equal(request.TenantId, result.TenantId);
        }

    }
}
