using System.Threading.Tasks;

namespace PhoneNumberMappingApi.Infrastructure.Interfaces.Services
{
    public interface IPhoneNumberService
    {
        string Map(string prefix, string phoneNumber);
    }
}
