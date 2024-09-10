using Microsoft.AspNetCore.Components.Forms;
using ShelterApp.Entities.Entities.Blog.dtos;

namespace ShelterApp.Pages.Blog
{
    public partial class BlogListPage
    {
        public string secilenDil;
        public List<string> dilList = new List<string>() { "TR", "GB", "RU" };
        public bool photoVisible = false;

        protected override async void OnInitialized()
        {
            
            BaseCrudService = BlogAppService;
        }
        protected override async Task BeforeInsertAsync()
        {
            DataSource = new SelectBlogDto();
            DataSource.Tarih = DateTime.Today;
            EditPageVisible = true;

            await Task.CompletedTask;
        }
        private async Task UploadFiles(InputFileChangeEventArgs e)
        {
            photoVisible = true;

            var file = e.File;

            if (file != null)
            {
                string rootPath = "wwwroot/images/blog";
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                                string filePath = rootPath+"/"+file.Name;

                using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.OpenReadStream(maxAllowedSize: 1024 * 3000).CopyToAsync(filestream);
                }


                DataSource.Foto = "images/blog"+ file.Name;

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


