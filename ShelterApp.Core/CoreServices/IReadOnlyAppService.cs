

using ShelterApp.Core.Utilities.Results;

namespace ShelterApp.Core.BusinessCoreServices
{
    public interface IReadOnlyAppService<TGetOutputDto, TGetListOutputDto>
    {
        Task<TGetOutputDto> GetAsync(int id);

        Task<IList<TGetListOutputDto>> GetListAsync();
    }
}
