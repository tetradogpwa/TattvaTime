// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace TattvaTimeBlazor.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\tetra\source\repos\TattvaTime\TattvaTimeBlazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tetra\source\repos\TattvaTime\TattvaTimeBlazor\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\tetra\source\repos\TattvaTime\TattvaTimeBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\tetra\source\repos\TattvaTime\TattvaTimeBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\tetra\source\repos\TattvaTime\TattvaTimeBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\tetra\source\repos\TattvaTime\TattvaTimeBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\tetra\source\repos\TattvaTime\TattvaTimeBlazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\tetra\source\repos\TattvaTime\TattvaTimeBlazor\_Imports.razor"
using TattvaTimeBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\tetra\source\repos\TattvaTime\TattvaTimeBlazor\_Imports.razor"
using TattvaTimeBlazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\tetra\source\repos\TattvaTime\TattvaTimeBlazor\_Imports.razor"
using TattvaTimeBlazor.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\tetra\source\repos\TattvaTime\TattvaTimeBlazor\_Imports.razor"
using TattvaTime;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\tetra\source\repos\TattvaTime\TattvaTimeBlazor\Shared\TattvaViewer.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
    public partial class TattvaViewer : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 14 "C:\Users\tetra\source\repos\TattvaTime\TattvaTimeBlazor\Shared\TattvaViewer.razor"
       

    Timer TimerTattva { get; set; }
    Tattva Tattva { get; set; }
    string ImgTattvaActual => $"./imgs/{Tattva.TattvaName}.png";
    [Parameter] public double Latitude { get; set; }
    [Parameter] public double Longitude { get; set; }
    [Parameter] public DateTime HoraActual { get; set; } = DateTime.Now;



    protected override void OnInitialized()
    {


        Tattva = new Tattva(HoraActual, Latitude, Longitude);
        TimerTattva = new Timer(NextTattva);
        TimerTattva.Change(Tattva.NextSubTattva, Tattva.CicloSubTattva);

        StateHasChanged();

    }


    void NextTattva(object state)
    {
        this.Tattva.Update();
        StateHasChanged();
    }
    public void Dispose() => TimerTattva.Dispose();


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
