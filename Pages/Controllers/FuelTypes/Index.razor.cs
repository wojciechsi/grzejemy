using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using grzejemy;
using grzejemy.Pages.Views.Shared;
using grzejemy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using grzejemy.Models;

namespace grzejemy.Pages.Views.FuelTypes
{
    public partial class Index
    {
        private List<FuelType> fuelTypes = new List<FuelType>();
        protected override async Task OnInitializedAsync()
        {
            fuelTypes = await dbContext.FuelTypes.ToListAsync();
        }

        private async Task DeleteFuelTypeAsync(FuelType fuelType)
        {
            dbContext.FuelTypes.Remove(fuelType);
            if (await dbContext.SaveChangesAsync() > 0)
            {
                fuelTypes.Remove(fuelType);
                await JsRuntime.InvokeVoidAsync("window.location.reload");
            }
            else
            {
                string errorMessage = $"ERROR: Failed to delete fuel type \"{fuelType.Name}\"";
                await JsRuntime.InvokeVoidAsync("alert", errorMessage);
            }
        }
    }
}