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
using System.Linq.Dynamic.Core;

namespace grzejemy.Pages.Views.Vendors
{
    public partial class Index
    {
        private IList<IdentityUser> vendorCandidates;
        protected override async Task OnInitializedAsync()
        {
            vendorCandidates = await _userManager.GetUsersInRoleAsync("vendor-candidate");
            vendorsDataGrid = vendorCandidates;
        }

        async Task<string> getUserId()
        {
            var user = (await _authenticationStateProvider.GetAuthenticationStateAsync()).User;
            var UserId = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return UserId;
        }

        IEnumerable<IdentityUser> vendorsDataGrid;

        private async Task confirmVendor(IdentityUser user)
        {
            var oldUserRole = dbContext.UserRoles.Find(user.Id, "VDRCAN");
            var newUserRole = new IdentityUserRole<string>();
            newUserRole.UserId = user.Id;
            newUserRole.RoleId = "VDR";
            dbContext.UserRoles.Remove(oldUserRole);
            dbContext.UserRoles.AddAsync(newUserRole);

            if (await dbContext.SaveChangesAsync() > 0)
            {
                NavManager.NavigateTo("/Vendors/"); //works wit asp.net tables
                await JsRuntime.InvokeVoidAsync("window.location.reload"); //work with radze tables
            }
            else
            {
                string errorMessage = "ERROR: Failed confirm vendor.";
                await JsRuntime.InvokeVoidAsync("alert", errorMessage);
            }
        }

        private async Task rejectVendor(IdentityUser user)
        {
            var oldUserRole = dbContext.UserRoles.Find(user.Id, "VDRCAN");
            var newUserRole = new IdentityUserRole<string>();
            newUserRole.UserId = user.Id;
            newUserRole.RoleId = "BYR";
            dbContext.UserRoles.Remove(oldUserRole);
            dbContext.UserRoles.AddAsync(newUserRole);

            if (await dbContext.SaveChangesAsync() > 0)
            {
                NavManager.NavigateTo("/Vendors/"); //works wit asp.net tables
                await JsRuntime.InvokeVoidAsync("window.location.reload"); //work with radze tables
            }
            else
            {
                string errorMessage = "ERROR: Failed confirm vendor.";
                await JsRuntime.InvokeVoidAsync("alert", errorMessage);
            }
        }
    }
}