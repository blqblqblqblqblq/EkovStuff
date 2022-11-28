using Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace API.Examples
{
    public class CreateTenantRequestExample : IExamplesProvider<CreateTenantRequest>
    {
        public CreateTenantRequest GetExamples()
        {
            return new CreateTenantRequest()
            {
                Name = "Mariscos Recio",
                Address1 = "Mirador de Montepinar",
                Address2 = "Mirador de Montepinar Fish Store",
                Country = "Spain",
                Email = "mariscos_recio@gmail.com",
                Locality = "Madrid Río",
                OrganisationType = "Company",
                Phone= "1234567890",
                PostCode= "1234"
            };
        }
    }
}
