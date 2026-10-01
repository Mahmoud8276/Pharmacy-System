using Pharmacy.System.Core.Dtos.PackagingUnitDtos;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Services.SpecificationParams;

namespace Pharmacy.System.Services.IServices
{
    public interface IPackagingUnitService 
        : IWriteService<PackagingUnit, int, PackagingUnitDto, PackagingUnitDto, PackagingUnitSpecParams>
    {
    }
}
