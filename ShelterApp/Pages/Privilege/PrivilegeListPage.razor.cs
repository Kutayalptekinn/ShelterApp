using Microsoft.AspNetCore.Components.Forms;
using ShelterApp.Business.Services.PrivilegeService;
using ShelterApp.Entities.Entities.Privilege.dtos;

namespace ShelterApp.Pages.Privilege
{
    public partial class PrivilegeListPage
    {
        protected override async void OnInitialized()
        {
            
            BaseCrudService = PrivilegeAppService;
        }
        protected override async Task BeforeInsertAsync()
        {
            DataSource = new SelectPrivilegeDto();
            EditPageVisible = true;

            await Task.CompletedTask;
        }
        private async Task UploadFiles(InputFileChangeEventArgs e)
        {
            var file = e.File;

            if (file != null)
            {
                Stream stream = e.File.OpenReadStream();

                using (var ms = new MemoryStream())
                {
                    await stream.CopyToAsync(ms);
                    DataSource.Photo = ms.ToArray();
                    await InvokeAsync(() => StateHasChanged());
                }
            }
        }

    }
}


