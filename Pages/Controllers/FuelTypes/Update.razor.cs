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
using grzejemy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace grzejemy.Pages.Views.FuelTypes
{
    public partial class Update
    {
        [Parameter]
        public int id { get; set; }

        private FuelType fuelTypeToUpdate = null;
        protected override async Task OnParametersSetAsync()
        {
            fuelTypeToUpdate = await dbContext.FuelTypes.FindAsync(id);
        }

        private async Task UpdatePostAsync()
        {
            dbContext.FuelTypes.Update(fuelTypeToUpdate);
            if (await dbContext.SaveChangesAsync() > 0)
            {
                NavigationManager.NavigateTo("/FuelTypes");
            }
            else
            {
                string errorMessage = "ERROR: Failed to update post.";
                await JsRuntime.InvokeVoidAsync("alert", errorMessage);
            }
        }
    }
}