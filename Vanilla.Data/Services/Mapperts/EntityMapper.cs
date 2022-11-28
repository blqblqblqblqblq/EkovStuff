using Models.Requests;
using Models.Responses;
using Vanilla.Data.Models;

namespace Services.Mapperts
{
    public static class EntityMapper
    {
        public static Tenant ToTenantEntity(this CreateTenantRequest createTenantRequest)
        {
            return new Tenant
            {
                Name = createTenantRequest.Name
            };
        }

        public static LegalEntity ToLegalEntity(this CreateTenantRequest createTenantRequest, Guid tenantId)
        {
            var entity = new LegalEntity
            {
                Addresses = new List<LegalEntityAddress>
                {
                    new LegalEntityAddress
                    {
                        Line1 = createTenantRequest.Address1,
                        Line2 = createTenantRequest.Address2,
                        Locality= createTenantRequest.Locality,
                        Country= createTenantRequest.Country,
                        PostCode= createTenantRequest.PostCode
                    }
                },
                EmailAddresses = new List<LegalEntityEmail>
                {
                    new LegalEntityEmail
                    {
                        Email= createTenantRequest.Email
                    }
                },
                PhoneNumbers = new List<LegalEntityPhone>
                {
                    new LegalEntityPhone
                    {
                        Phone = createTenantRequest.Phone
                    }
                },
                TenantId = tenantId
            };

            switch (createTenantRequest.OrganisationType)
            {
                case "VoluntaryOrganisation":
                    {
                        entity.LegalEntityType = LegalEntityType.VoluntaryOrganisation;
                        break;
                    }
                case "SocialEnterprise":
                    {
                        entity.LegalEntityType = LegalEntityType.Company;
                        break;
                    }
                case "Company":
                    {
                        entity.LegalEntityType = LegalEntityType.Company;
                        break;
                    }
            }

            return entity;
        }

        public static MembershipGroup ToMembershipGroup(this CreateMembershipGroupRequest createMembershipGroupRequest)
        {
            var entity = new MembershipGroup
            {
                Description = createMembershipGroupRequest.Description,
                GroupName = createMembershipGroupRequest.GroupName,
                TenantId = createMembershipGroupRequest.TenantId,
                FeeAmount = createMembershipGroupRequest.FeeAmount
            };

            switch (createMembershipGroupRequest.FeeType)
            {
                case "NoFeeRequired":
                    {
                        entity.FeeType = MembershipFeeType.NoFeeRequired;
                        break;
                    }
                case "MonthlyFee":
                    {
                        entity.FeeType = MembershipFeeType.MonthlyFee;
                        break;
                    }
                case "AnnualFee":
                    {
                        entity.FeeType = MembershipFeeType.AnnualFee;
                        break;
                    }
            }

            return entity;
        }

        public static MembershipGroup ToMembershipGroup(this UpdateMembershipGroupRequest updateMembershipGroupRequest)
        {
            var entity = new MembershipGroup
            {
                Id= updateMembershipGroupRequest.Id,
                Description = updateMembershipGroupRequest.Description,
                GroupName = updateMembershipGroupRequest.GroupName,
                TenantId = updateMembershipGroupRequest.TenantId,
                FeeAmount = updateMembershipGroupRequest.FeeAmount
            };

            switch (updateMembershipGroupRequest.FeeType)
            {
                case "NoFeeRequired":
                    {
                        entity.FeeType = MembershipFeeType.NoFeeRequired;
                        break;
                    }
                case "MonthlyFee":
                    {
                        entity.FeeType = MembershipFeeType.MonthlyFee;
                        break;
                    }
                case "AnnualFee":
                    {
                        entity.FeeType = MembershipFeeType.AnnualFee;
                        break;
                    }
            }

            return entity;
        }

        public static MembershipGroupResponse ToCreateMembershipGroupResponse(this MembershipGroup membershipGroup)
        {
            return new MembershipGroupResponse
            {
                Description = membershipGroup.Description,
                GroupName = membershipGroup.GroupName,
                FeeAmount = membershipGroup.FeeAmount,
                TenantId = membershipGroup.TenantId,
                Id = membershipGroup.Id,
                FeeType = membershipGroup.FeeType.ToString()
            };
        }
    }
}
