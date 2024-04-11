

using ShelterApp.Core.Utilities.Results;

namespace ShelterApp.Core.BusinessCoreServices
{
    public interface IDeleteAppService
    {
        Task DeleteAsync(int id);
    }
}
