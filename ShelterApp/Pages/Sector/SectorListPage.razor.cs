using Microsoft.AspNetCore.Components.Forms;
using ShelterApp.Business.Services.SectorService;
using ShelterApp.Entities.Entities.Sector.dtos;

namespace ShelterApp.Pages.Sector
{
    public partial class SectorListPage
    {
        protected override async void OnInitialized()
        {
            
            BaseCrudService = SectorAppService;
        }
        protected override async Task BeforeInsertAsync()
        {
            DataSource = new SelectSectorDto();
            EditPageVisible = true;

            await Task.CompletedTask;
        }
        private async Task UploadFiles1(InputFileChangeEventArgs e)
        {
            var file = e.File;

            if (file != null)
            {
                Stream stream = e.File.OpenReadStream();

                using (var ms = new MemoryStream())
                {
                    await stream.CopyToAsync(ms);
                    DataSource.Photo1 = ms.ToArray();
                    await InvokeAsync(() => StateHasChanged());
                }
            }
        }
        private async Task UploadFiles2(InputFileChangeEventArgs e)
        {
            var file = e.File;

            if (file != null)
            {
                Stream stream = e.File.OpenReadStream();

                using (var ms = new MemoryStream())
                {
                    await stream.CopyToAsync(ms);
                    DataSource.Photo2 = ms.ToArray();
                    await InvokeAsync(() => StateHasChanged());
                }
            }
        }
        private async Task UploadFiles3(InputFileChangeEventArgs e)
        {
            var file = e.File;

            if (file != null)
            {
                Stream stream = e.File.OpenReadStream();

                using (var ms = new MemoryStream())
                {
                    await stream.CopyToAsync(ms);
                    DataSource.Photo3 = ms.ToArray();
                    await InvokeAsync(() => StateHasChanged());
                }
            }
        }
        private async Task UploadFiles4(InputFileChangeEventArgs e)
        {
            var file = e.File;

            if (file != null)
            {
                Stream stream = e.File.OpenReadStream();

                using (var ms = new MemoryStream())
                {
                    await stream.CopyToAsync(ms);
                    DataSource.FrontPhoto = ms.ToArray();
                    await InvokeAsync(() => StateHasChanged());
                }
            }
        }
    }
}


