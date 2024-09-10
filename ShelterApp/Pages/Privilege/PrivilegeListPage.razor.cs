using Microsoft.AspNetCore.Components.Forms;
using ShelterApp.Business.Services.PrivilegeService;
using ShelterApp.Entities.Entities.Privilege.dtos;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace ShelterApp.Pages.Privilege
{
    public partial class PrivilegeListPage
    {
        public bool photoVisible=false;
        public string secilenDil;
        public List<string> dilList = new List<string>() { "TR","GB","RU" };
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
            photoVisible = true;
            var file = e.File;

            if (file != null)
            {
                string rootPath = "wwwroot/images/privilege";
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                                string filePath = rootPath+"/"+file.Name;

                using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.OpenReadStream(maxAllowedSize: 1024 * 3000).CopyToAsync(filestream);
                }


                DataSource.Photo = "images/privilege/"+ file.Name;

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


