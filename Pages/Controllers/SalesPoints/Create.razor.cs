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

namespace grzejemy.Pages.Views.SalesPoints
{
    public partial class Create
    {
        private SalesPoint salesPointToAdd = new SalesPoint();
        private string currUserId = string.Empty;
        async Task<string> getUserId()
        {
            var user = (await _authenticationStateProvider.GetAuthenticationStateAsync()).User;
            var UserId = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return UserId;
        }

        protected override async Task OnInitializedAsync()
        {
            currUserId = await getUserId();
        }

        private async Task CreateSalesPointAsync()
        {
            var user = dbContext.Users.Find(await getUserId());
            salesPointToAdd.Vendor = user;
            await dbContext.SalesPoints.AddAsync(salesPointToAdd);
            if (await dbContext.SaveChangesAsync() > 0)
            {
                NavigationManager.NavigateTo("/SalesPoints");
            }
            else
            {
                string errorMessage = "ERROR: Failed to create sales point.";
                await JsRuntime.InvokeVoidAsync("alert", errorMessage);
            }
        }
    }
}