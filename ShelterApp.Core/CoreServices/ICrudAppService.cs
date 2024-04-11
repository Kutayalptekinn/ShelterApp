using ShelterApp.Core.BusinessCoreServices;

namespace ShelterApp.Core.BusinessCoreServices
{
    public interface ICrudAppService< TGetOutputDto, TGetListOutputDto, in TCreateInput, in TUpdateInput> :
        ICreateAppService<TGetOutputDto, TCreateInput>,
        IUpdateAppService<TGetOutputDto, TUpdateInput>,
        IDeleteAppService,
        IReadOnlyAppService<TGetOutputDto,TGetListOutputDto>
    {
    }
}