using Microsoft.AspNetCore.Components.Forms;
using ShelterApp.Entities.Entities.Product.dtos;

namespace ShelterApp.Pages.Product
{
    public partial class ProductListPage
    {
        public string secilenDil;
        public List<string> dilList = new List<string>() { "TR", "GB", "RU" };
        public bool photoVisible = false;
        public bool photoVisible1 = false;
        public bool photoVisible2 = false;
        public bool photoVisible3 = false;

        protected override async void OnInitialized()
        {
            
            BaseCrudService = ProductAppService;
        }
        protected override async Task BeforeInsertAsync()
        {
            DataSource = new SelectProductDto();
            DataSource.Baslik = "";
            EditPageVisible = true;

            await Task.CompletedTask;
        }
        private async Task UploadFiles(InputFileChangeEventArgs e)
        {
            photoVisible = true;

            var file = e.File;

            if (file != null)
            {
                string rootPath = "wwwroot/images/product";
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                string filePath = rootPath+"/"+file.Name;

                using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.OpenReadStream(maxAllowedSize: 1024 * 3000).CopyToAsync(filestream);
                }


                DataSource.FrontPhoto = "images/product/"+ file.Name;

            }
            photoVisible = false;

        }
        private async Task UploadFiles1(InputFileChangeEventArgs e)
        {
            photoVisible1 = true;

            var file = e.File;

            if (file != null)
            {
                string rootPath = "wwwroot/images/product";
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                string filePath = rootPath + "/" + file.Name;

                using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.OpenReadStream(maxAllowedSize: 1024 * 3000).CopyToAsync(filestream);
                }


                DataSource.Photo1 = "images/product/" + file.Name;

            }
            photoVisible1 = false;

        }
        private async Task UploadFiles2(InputFileChangeEventArgs e)
        {
            photoVisible2 = true;

            var file = e.File;

            if (file != null)
            {
                string rootPath = "wwwroot/images/product";
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                string filePath = rootPath + "/" + file.Name;

                using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.OpenReadStream(maxAllowedSize: 1024 * 3000).CopyToAsync(filestream);
                }


                DataSource.Photo2 = "images/product/" + file.Name;

            }
            photoVisible2 = false;

        }
        private async Task UploadFiles3(InputFileChangeEventArgs e)
        {
            photoVisible3 = true;

            var file = e.File;

            if (file != null)
            {
                string rootPath = "wwwroot/images/product";
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                string filePath = rootPath + "/" + file.Name;

                using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.OpenReadStream(maxAllowedSize: 1024 * 3000).CopyToAsync(filestream);
                }


                DataSource.Photo3 = "images/product/" + file.Name;

            }
            photoVisible3 = false;

        }
        private async void OnDilValueChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, string> args)
        {
            //secilenDil = args.Value;
            DataSource.Language = args.Value;
            await InvokeAsync(StateHasChanged);
        }
    }
}


