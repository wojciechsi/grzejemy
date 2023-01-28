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
    public partial class Index
    {
        private List<SalesPoint> salesPoints = new List<SalesPoint>();
        private string currUserId = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            currUserId = await getUserId();
            salesPoints = await dbContext.SalesPoints.Include(s => s.Vendor).Where(s => s.Vendor.Id.Equals(currUserId)).ToListAsync();
            salesPointsDataGrid = salesPoints;
        }

        async Task<string> getUserId()
        {
            var user = (await _authenticationStateProvider.GetAuthenticationStateAsync()).User;
            var UserId = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return UserId;
        }

        private async Task DeleteSalesAsync(SalesPoint salesPoint)
        {
            dbContext.SalesPoints.Remove(salesPoint);
            if (await dbContext.SaveChangesAsync() > 0)
            {
                salesPoints.Remove(salesPoint);
                await JsRuntime.InvokeVoidAsync("window.location.reload");
            }
            else
            {
                string errorMessage = $"ERROR: Failed to delete sales point \"{salesPoint.Name}\"";
                await JsRuntime.InvokeVoidAsync("alert", errorMessage);
            }
        }

        IEnumerable<SalesPoint> salesPointsDataGrid;


        void UpdateSalesPoint(int salesPoinId)
        {
            NavManager.NavigateTo("/SalesPoints/Update/" + salesPoinId);
        }

        void CreateSalesPoint()
        {
            NavManager.NavigateTo("/SalesPoints/Create/");
        }


    }
}