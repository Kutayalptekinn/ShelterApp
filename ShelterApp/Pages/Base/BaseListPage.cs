
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using ShelterApp.Core.BusinessCoreServices;
using ShelterApp.Core.Entities;
using ShelterApp.Core.Utilities.MapperUtilities.Extensions;
using ShelterApp.UI.Utilities.ModalUtilities;
using Syncfusion.Blazor.Buttons;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Inputs;
using Syncfusion.Blazor.Navigations;
using System.Text;

namespace ShelterApp.UI.Pages.Base
{
    public abstract class BaseListPage<TGetOutputDto, TGetListOutputDto, TCreateInput, TUpdateInput> : ComponentBase
         where TGetOutputDto : class, IEntityDto, new()
         where TGetListOutputDto : class, IEntityDto, new()
    {

        public string LoadingCaption { get; set; }
        public string LoadingText { get; set; }
        public bool EditPageVisible { get; set; }
        public bool IsLoaded { get; set; }

        public bool IsChanged { get; set; } = false;
        public bool SelectFirstDataRow { get; set; }

        public string[] MenuItems = new string[] { "Group", "Ungroup", "ColumnChooser", "Filter" };

        public string toolbarSearchKey = string.Empty;

        public TGetListOutputDto SelectedItem { get; set; }

        //[Inject]
        //ModalManager ModalManager { get; set; }

        [Inject]
        IJSRuntime JsRuntime { get; set; }

        public TGetOutputDto DataSource { get; set; }
        public IList<TGetListOutputDto> ListDataSource { get; set; }

        public SfGrid<TGetListOutputDto> _grid;

        public SfGrid<TGetListOutputDto> ButtonEditGrid;

        public bool AllowGridPaging { get; set; } = true;

        public int GridPageSize { get; set; } = 35;


        public List<ContextMenuItemModel> GridContextMenu { get; set; } = new List<ContextMenuItemModel>();

        public List<ItemModel> GridToolbarItems { get; set; } = new List<ItemModel>();

        public string GridSearchText { get; set; }

        protected ICrudAppService<TGetOutputDto, TGetListOutputDto, TCreateInput, TUpdateInput> BaseCrudService { get; set; }



        protected async override Task OnParametersSetAsync()
        {


                LoadingCaption = "Yükleniyor";
                LoadingText = "Veriler hazırlanıyor..";

                //CreateContextMenuItems();
                CreateGridToolbar();
                
            

            await GetListDataSourceAsync();
            await InvokeAsync(StateHasChanged);
        }


        #region Crud Operations
        protected virtual async void EditItem(TGetListOutputDto item)
        {
            IsChanged = true;
            SelectFirstDataRow = false;
            var selectItem = await GetAsync(item.ID);
            DataSource = selectItem ;
            ShowEditPage();
            await InvokeAsync(StateHasChanged);
        }

        protected async void DeleteItem(TGetListOutputDto item)
        {

            await JsRuntime.InvokeVoidAsync("confirmDelete", "Bilgi", "Kayıt kalıcı olarak silinecektir.");

            SelectFirstDataRow = false;
            await DeleteAsync(item.ID);
            await GetListDataSourceAsync();
            await InvokeAsync(StateHasChanged);
            SelectFirstDataRow = false;
                await DeleteAsync(item.ID);
                await GetListDataSourceAsync();
                await InvokeAsync(StateHasChanged);
        }
        protected async virtual Task<TGetOutputDto> GetAsync(int id)
        {

            try
            {
                return await BaseCrudService.GetAsync(id);
            }
            catch (Exception exp)
            {
                if (exp.InnerException != null)
                {
                    await JsRuntime.InvokeVoidAsync("confirmDelete", "Bilgi", exp.InnerException.Message);
                }
                else
                {
                    await JsRuntime.InvokeVoidAsync("confirmDelete", "Hata", exp.Message);
                }

                return default(TGetOutputDto);
            }
        }

        protected async virtual Task<IList<TGetListOutputDto>> GetListAsync()
        {
            try
            {
                var list=(await BaseCrudService.GetListAsync());
                return list;
            }
            catch (Exception exp)
            {
                if (exp.InnerException != null)
                {
                    await JsRuntime.InvokeVoidAsync("confirmDelete", "Bilgi", exp.InnerException.Message);
                }
                else
                {
                    await JsRuntime.InvokeVoidAsync("confirmDelete", "Hata", exp.Message);
                }

                return null;
            }
        }

        protected async virtual Task<TGetOutputDto> CreateAsync(TCreateInput input)
        {
            try
            {
                return await BaseCrudService.CreateAsync(input);
            }
            //catch (DuplicateCodeException exp)
            //{
            //    await ModalManager.MessagePopupAsync("Bilgi", exp.Message);
            //    return new ErrorDataResult<TGetOutputDto>();
            //}
            //catch (ValidationException exp)
            //{
            //    var errorList = exp.Errors.ToList();

            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine("<ul>");

            //    for (int i = 0; i < errorList.Count; i++)
            //    {
            //        sb.AppendLine("<li>" + errorList[i].ErrorMessage + "</li>");
            //    }

            //    sb.AppendLine("</ul>");

            //    await ModalManager.MessagePopupAsync("Bilgi", sb.ToString());
            //    return new ErrorDataResult<TGetOutputDto>();
            //}
            catch (Exception exp)
            {
                if (exp.InnerException != null)
                {
                    await JsRuntime.InvokeVoidAsync("confirmDelete", "Bilgi", "Bilgileri eksiksiz doldurunuz");
                }
                else
                {
                    await JsRuntime.InvokeVoidAsync("confirmDelete", "Hata", "Bilgileri eksiksiz doldurunuz");
                }

                return new TGetOutputDto();
            }
        }

        protected async virtual Task<TGetOutputDto> UpdateAsync(TUpdateInput input)
        {
            try
            {
                return await BaseCrudService.UpdateAsync(input);
            }
            //catch (DuplicateCodeException exp)
            //{
            //    await ModalManager.MessagePopupAsync("Bilgi", exp.Message);
            //    return new ErrorDataResult<TGetOutputDto>();
            //}
            //catch (ValidationException exp)
            //{
            //    var errorList = exp.Errors.ToList();

            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine("<ul>");

            //    for (int i = 0; i < errorList.Count; i++)
            //    {
            //        sb.AppendLine("<li>" + errorList[i].ErrorMessage + "</li>");
            //    }

            //    sb.AppendLine("</ul>");

            //    await ModalManager.MessagePopupAsync("Bilgi", sb.ToString());
            //    return new ErrorDataResult<TGetOutputDto>();
            //}
            catch (Exception exp)
            {
                if (exp.InnerException != null)
                {
                    await JsRuntime.InvokeVoidAsync("confirmDelete", "Bilgi", "Bilgileri eksiksiz doldurunuz");
                }
                else
                {
                    await JsRuntime.InvokeVoidAsync("confirmDelete", "Hata", "Bilgileri eksiksiz doldurunuz");
                }
                return new TGetOutputDto();
            }
        }

        protected async virtual Task DeleteAsync(int id)
        {

            try
            {
               await BaseCrudService.DeleteAsync(id);
            }
            catch (Exception exp)
            {
                if (exp.InnerException != null)
                {
                    await JsRuntime.InvokeVoidAsync("confirmDelete", "Bilgi", "Hata");
                }
                else
                {
                    await JsRuntime.InvokeVoidAsync("confirmDelete", "Hata", "Hata");
                }

            }
        }

        #endregion

        protected virtual async Task GetListDataSourceAsync()
        {
            ListDataSource = (await GetListAsync()).ToList();

            IsLoaded = true;
        }

        protected virtual async Task OnSubmit()
        {
            TGetOutputDto result;

            if (DataSource.ID == 0)
            {
                var createInput = ObjectMapper.Map<TGetOutputDto, TCreateInput>(DataSource);

                result = (await CreateAsync(createInput)) ;

                if (result != null)
                    DataSource.ID = result.ID;
            }
            else
            {
                var updateInput = ObjectMapper.Map<TGetOutputDto, TUpdateInput>(DataSource);

                result = (await UpdateAsync(updateInput)) ;
            }

            if (result == null)
            {

                return;
            }

            await GetListDataSourceAsync();

            //var savedEntityIndex = ListDataSource.FindIndex(x => x.ID == DataSource.ID);

            HideEditPage();

            if (DataSource.ID == 0)
            {
                DataSource.ID = result.ID;
            }

            //if (savedEntityIndex > -1)
            //    //SelectedItem = ListDataSource.SetSelectedItem(savedEntityIndex);
            //else
            //    SelectedItem = ListDataSource.GetEntityById(DataSource.ID);
        }

        public virtual void HideEditPage()
        {
            EditPageVisible = false;
            InvokeAsync(StateHasChanged);
        }

        public async virtual void ShowEditPage()
        {
            if (DataSource != null)
            {
                EditPageVisible = true;
                await InvokeAsync(StateHasChanged);
            }
        }


        protected virtual async Task BeforeInsertAsync()
        {
            DataSource = new TGetOutputDto();

            EditPageVisible = true;

            await Task.CompletedTask;
        }


        #region Grid Toolbar Methods


        public async void OnToolbarSearchChange(KeyboardEventArgs e)
        {
            if (e.Code == "Enter" || e.Code == "NumpadEnter")
            {
                if (!string.IsNullOrEmpty(GridSearchText))
                {
                    await _grid.SearchAsync(GridSearchText.ToLower());

                    await JsRuntime.InvokeVoidAsync("focusInput", "srcText");
                }
                else
                {
                    await _grid.SearchAsync("");

                    await JsRuntime.InvokeVoidAsync("focusInput", "srcText");
                }
            }
        }

        public void CreateGridToolbar()
        {
            RenderFragment search = (builder) =>
            {
                builder.OpenComponent(0, typeof(SfTextBox));
                builder.AddAttribute(1, "ID", "srcText");
                builder.AddAttribute(2, "Value", BindConverter.FormatValue(GridSearchText));
                builder.AddAttribute(3, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => GridSearchText = __value, GridSearchText));
                builder.AddAttribute(4, "onkeydown", OnToolbarSearchChange);
                builder.AddAttribute(5, "ShowClearButton", true);
                builder.CloseComponent();
            };


            GridToolbarItems.Add(new ItemModel() { Id = "InsertButton", CssClass = "InsertButton", Type = ItemType.Button, PrefixIcon = "InsertIcon", TooltipText = "Yeni Kayıt Ekle" });

            GridToolbarItems.Add(new ItemModel() { Id = "Search", Type = ItemType.Input, Template = search, Text = GridSearchText });


        }


        public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Id == "InsertButton")
            {
                await BeforeInsertAsync();
            }
          

        }
        #endregion
    }
}
