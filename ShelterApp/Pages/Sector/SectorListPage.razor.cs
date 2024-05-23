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
                string rootPath = "wwwroot/images/sector";
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                string filePath = Path.Combine(rootPath, file.Name);

                using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.OpenReadStream(maxAllowedSize: 1024 * 3000).CopyToAsync(filestream);
                }


                DataSource.Photo1 = Path.Combine("images/sector", file.Name);

                //    Stream stream = e.File.OpenReadStream(maxAllowedSize: 1024 * 3000);

                //    using (var ms = new MemoryStream())
                //    {
                //        await stream.CopyToAsync(ms);
                //        DataSource.Photo1 = ms.ToArray();
                //        await InvokeAsync(() => StateHasChanged());
                //    }
            }
        }
        private async Task UploadFiles2(InputFileChangeEventArgs e)
        {
            var file = e.File;

            if (file != null)
            {
                string rootPath = "wwwroot/images/sector";
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                string filePath = Path.Combine(rootPath, file.Name);

                using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.OpenReadStream(maxAllowedSize: 1024 * 3000).CopyToAsync(filestream);
                }


                DataSource.Photo2 = Path.Combine("images/sector", file.Name);
            }
        }
        private async Task UploadFiles3(InputFileChangeEventArgs e)
        {
            var file = e.File;

            if (file != null)
            {
                string rootPath = "wwwroot/images/sector";
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                string filePath = Path.Combine(rootPath, file.Name);

                using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.OpenReadStream(maxAllowedSize: 1024 * 3000).CopyToAsync(filestream);
                }


                DataSource.Photo3 = Path.Combine("images/sector", file.Name);
            }
        }
        private async Task UploadFiles4(InputFileChangeEventArgs e)
        {
            var file = e.File;

            if (file != null)
            {
                string rootPath = "wwwroot/images/sector";
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                string filePath = Path.Combine(rootPath, file.Name);

                using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.OpenReadStream(maxAllowedSize: 1024 * 3000).CopyToAsync(filestream);
                }


                DataSource.FrontPhoto = Path.Combine("images/sector", file.Name);
            }
        }
    }
}


