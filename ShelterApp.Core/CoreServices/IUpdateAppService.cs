using ShelterApp.Core.Utilities.Results;

namespace ShelterApp.Core.BusinessCoreServices
{
    public interface IUpdateAppService<TGetOutputDto, in TUpdateInput>
    {
        Task<TGetOutputDto> UpdateAsync(TUpdateInput input);
    }
}
