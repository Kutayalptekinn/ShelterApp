using Microsoft.AspNetCore.Components.Forms;
using ShelterApp.Entities.Entities.Service.dtos;

namespace ShelterApp.Pages.Service
{
    public partial class ServiceListPage
    {
        protected override async void OnInitialized()
        {
            
            BaseCrudService = ServiceAppService;
        }
        protected override async Task BeforeInsertAsync()
        {
            DataSource = new SelectServiceDto();
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
                    DataSource.Foto = ms.ToArray();
                    await InvokeAsync(() => StateHasChanged());
                }
                //// Dosyanın Base64'e dönüştürülmesi
                //var buffer = new byte[file.Size];
                //await file.OpenReadStream().ReadAsync(buffer);
                //var base64 = Convert.ToBase64String(buffer);

                //// Base64 dizesinin DataSource.Resim özelliğine atanması
                //DataSource.Foto = Convert.FromBase64String(base64);
            }
        }
    }
}


