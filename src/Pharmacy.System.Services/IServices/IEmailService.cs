using Pharmacy.System.Core.Interfaces;
using System.Threading.Tasks;

namespace Pharmacy.System.Services.IServices
{
    public interface IEmailService
    {
        public Task SendAsync(IEmailStructure email);
    }
}
