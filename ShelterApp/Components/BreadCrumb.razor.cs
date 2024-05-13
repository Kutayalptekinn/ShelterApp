using Microsoft.AspNetCore.Components;

namespace ShelterApp.UI.Components
{
    public partial class BreadCrumb
    {
        [Parameter, EditorRequired] public string PreviousMenus { get; set; }

        [Parameter, EditorRequired] public string CurrentMenu { get; set; }
    }
}
