

using ShelterApp.Core.Utilities.Results;

namespace ShelterApp.Core.BusinessCoreServices
{
    public interface ICreateAppService<TGetOutputDto, in TCreateInput>
    {
        Task<TGetOutputDto> CreateAsync(TCreateInput input);
    }
}
