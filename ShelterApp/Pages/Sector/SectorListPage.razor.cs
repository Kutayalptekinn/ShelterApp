using Microsoft.AspNetCore.Components.Forms;
using ShelterApp.Business.Services.SectorService;
using ShelterApp.Entities.Entities.Sector.dtos;

namespace ShelterApp.Pages.Sector
{
    public partial class SectorListPage
    {
        public bool photoVisible = false;

        public string secilenDil;
        public List<string> dilList = new List<string>() { "TR", "GB", "RU" };
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
            photoVisible = true;

            var file = e.File;

            if (file != null)
            {
                string rootPath = "wwwroot/images/sector";
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                                string filePath = rootPath+"/"+file.Name;

                using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.OpenReadStream(maxAllowedSize: 1024 * 3000).CopyToAsync(filestream);
                }


                DataSource.Photo1 = "images/sector/"+ file.Name;

                //    Stream stream = e.File.OpenReadStream(maxAllowedSize: 1024 * 3000);

                //    using (var ms = new MemoryStream())
                //    {
                //        await stream.CopyToAsync(ms);
                //        DataSource.Photo1 = ms.ToArray();
                //        await InvokeAsync(() => StateHasChanged());
                //    }

            }
            photoVisible = false;

        }
        private async Task UploadFiles2(InputFileChangeEventArgs e)
        {
            photoVisible = true;

            var file = e.File;

            if (file != null)
            {
                string rootPath = "wwwroot/images/sector";
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                                string filePath = rootPath+"/"+file.Name;

                using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.OpenReadStream(maxAllowedSize: 1024 * 3000).CopyToAsync(filestream);
                }


                DataSource.Photo2 = "images/sector/" + file.Name;

            }

            //var buffer = new byte[file.Size];
            //await file.OpenReadStream(maxAllowedSize: 1024 * 3000).ReadAsync(buffer);
            //var base64 = Convert.ToBase64String(buffer);

            //// Base64 dizesinin DataSource.Resim özelliğine atanması
            //DataSource.Photo = Convert.FromBase64String(base64);
            photoVisible = false;

        }
        private async Task UploadFiles3(InputFileChangeEventArgs e)
        {
            photoVisible = true;

            var file = e.File;

            if (file != null)
            {
                string rootPath = "wwwroot/images/sector";
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                                string filePath = rootPath+"/"+file.Name;

                using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.OpenReadStream(maxAllowedSize: 1024 * 3000).CopyToAsync(filestream);
                }


                DataSource.Photo3 = "images/sector/" + file.Name;
            }
            photoVisible = false;

        }
        private async Task UploadFiles4(InputFileChangeEventArgs e)
        {
            photoVisible = true;

            var file = e.File;

            if (file != null)
            {
                string rootPath = "wwwroot/images/sector";
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                                string filePath = rootPath+"/"+file.Name;

                using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.OpenReadStream(maxAllowedSize: 1024 * 3000).CopyToAsync(filestream);
                }


                DataSource.FrontPhoto = "images/sector/" + file.Name;
            }
            photoVisible = false;

        }
        private async void OnDilValueChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, string> args)
        {
            //secilenDil = args.Value;
            DataSource.Language = args.Value;
            await InvokeAsync(StateHasChanged);
        }
    }
}


