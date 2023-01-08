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
using System.Xml.Linq;
using Radzen;
using System.Text.RegularExpressions;

namespace grzejemy.Pages.Views.Comments
{
    public partial class Create
    {

        private Comment commentToAdd = new Comment();
        private Offer offer = new Offer();
        private IdentityUser author = new IdentityUser();
        [Parameter] public int id { get; set; }

        private string currUserId = string.Empty;

        private string imageString = string.Empty;
        async Task<string> getUserId()
        {
            var user = (await _authenticationStateProvider.GetAuthenticationStateAsync()).User;
            var UserId = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return UserId;
        }
        protected override async Task OnParametersSetAsync()
        {
            offer = await dbContext.Offers.FindAsync(id);
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            currUserId = await getUserId();
            author = await dbContext.Users.FindAsync(currUserId);
        }

        private async Task CreateCommentAsync()
        {
            commentToAdd.Offer = offer;
            commentToAdd.Author = author;

            string formattedImageString = Regex.Replace(imageString, @"^data:image\/[a-zA-Z]+;base64,", string.Empty);

            byte[] image = Convert.FromBase64String(formattedImageString);

            commentToAdd.ParagonPhoto = image;

            await dbContext.Comments.AddAsync(commentToAdd);
            if (await dbContext.SaveChangesAsync() > 0)
            {
                NavigationManager.NavigateTo("/Offers/" + @offer.Id + "/Comments");
            }
            else
            {
                string errorMessage = "ERROR: Failed to create comment.";
                await JsRuntime.InvokeVoidAsync("alert", errorMessage);
            }
        }

        void OnChange(byte[] value)
        {
            
        }

    }
}