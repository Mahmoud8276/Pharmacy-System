using Pharmacy.System.Core.Interfaces.ISpecificationParams;

namespace Pharmacy.System.Services.SpecificationParams
{
    public class UserSpecParams : BaseSpecParams, IUserSpecParams
    {
        public string? UserName { get; set; }
    }
}
