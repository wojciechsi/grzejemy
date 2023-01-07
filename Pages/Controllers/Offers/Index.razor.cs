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
    public partial class Index
    {
        private List<Offer> offers = new List<Offer>();
        private string currUserId = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            offers = await dbContext.Offers
                .Include(s => s.SalesPoint)
                    .ThenInclude(v => v.Vendor)
                .Include(f => f.FuelType)
                .ToListAsync();
            currUserId = await getUserId();
        }

        async Task<string> getUserId()
        {
            var user = (await _authenticationStateProvider.GetAuthenticationStateAsync()).User;
            var UserId = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return UserId;
        }

        private async Task DeleteOfferAsync(Offer offer)
        {
            dbContext.Offers.Remove(offer);
            if (await dbContext.SaveChangesAsync() > 0)
            {
                offers.Remove(offer);
            }
            else
            {
                string errorMessage = $"ERROR: Failed to delete offer";
                await JsRuntime.InvokeVoidAsync("alert", errorMessage);
            }
            NavManager.NavigateTo("/Offers");
        }

        IEnumerable<Offer> offersDataGrid;

        protected override void OnInitialized()
        {
            offersDataGrid = dbContext.Offers.ToList();
        }

        void GoToComments(int offerId)
        {
            NavManager.NavigateTo("/Offers/" + offerId + "/Comments/ ");
        }

        void GoToEdit(int offerId)
        {
            NavManager.NavigateTo("/Offers/Update/"+offerId);
        }
    }
    
}