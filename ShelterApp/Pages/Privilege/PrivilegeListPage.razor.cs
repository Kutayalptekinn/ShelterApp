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
                Stream stream = e.File.OpenReadStream(maxAllowedSize: 1024 * 3000);

                using (var ms = new MemoryStream())
                {
                    await stream.CopyToAsync(ms);
                    //DataSource.Photo = ms.ToArray();
                    await InvokeAsync(() => StateHasChanged());
                }
                //var buffer = new byte[file.Size];
                //await file.OpenReadStream(maxAllowedSize: 1024 * 3000).ReadAsync(buffer);
                //var base64 = Convert.ToBase64String(buffer);

                //// Base64 dizesinin DataSource.Resim özelliğine atanması
                //DataSource.Photo = Convert.FromBase64String(base64);
            }
        }

    }
}


