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

namespace grzejemy.Pages.Views.Offers
{
    public partial class Create
    {
        private Offer offerToAdd = new Offer();
        private List<FuelType> fuelTypes = new List<FuelType>();
        private List<SalesPoint> salesPoints = new List<SalesPoint>();
        private int fuelTypeId = 0;
        private int salesPointId = 0;
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
            fuelTypes = await dbContext.FuelTypes.AsNoTracking().ToListAsync();
            salesPoints = await dbContext.SalesPoints.Where(s => s.Vendor.Id.Equals(currUserId)).ToListAsync();
        }

        private async Task CreateOfferAsync()
        {
            offerToAdd.FuelType = dbContext.FuelTypes.Find(fuelTypeId);
            offerToAdd.SalesPoint = dbContext.SalesPoints.Find(salesPointId);
            offerToAdd.Date = DateTime.Now;
            await dbContext.Offers.AddAsync(offerToAdd);
            if (await dbContext.SaveChangesAsync() > 0)
            {
                NavigationManager.NavigateTo("/Offers");
            }
            else
            {
                string errorMessage = "ERROR: Failed to create offer.";
                await JsRuntime.InvokeVoidAsync("alert", errorMessage);
            }
        }
    }
}