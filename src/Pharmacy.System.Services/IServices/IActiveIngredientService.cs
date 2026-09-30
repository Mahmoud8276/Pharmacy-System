using Pharmacy.System.Core.Dtos.ActiveIngredientDtos;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Services.SpecificationParams;

namespace Pharmacy.System.Services.IServices
{
    public interface IActiveIngredientService 
        : IWriteService<ActiveIngredient, int, ActiveIngredientDto, ActiveIngredientDto, ActiveIngredientSpecParams>
    {
    }
}
