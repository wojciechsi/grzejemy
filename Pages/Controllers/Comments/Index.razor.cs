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

namespace grzejemy.Pages.Views.Comments
{
    public partial class Index
    {

        [Parameter] public int id { get; set; }

        private Offer offer = null;
        private List<Comment> comments = new List<Comment>();

        private string currUserId = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            currUserId = await getUserId();
        }

        protected override async Task OnParametersSetAsync()
        {
            offer = await dbContext.Offers.FindAsync(id);
            comments = await dbContext.Comments
                .Where(c => c.Offer.Id == id)
                .ToListAsync();
        }

        async Task<string> getUserId()
        {
            var user = (await _authenticationStateProvider.GetAuthenticationStateAsync()).User;
            var UserId = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return UserId;
        }
        private async Task DeleteCommentAsync(Comment comment)
        {
            dbContext.Comments.Remove(comment);        
            if (await dbContext.SaveChangesAsync() > 0)
            {                                          
                comments.Remove(comment);
                reload();
            }
            else
            {
                string errorMessage = "ERROR: Failed to delete comment";
                await JsRuntime.InvokeVoidAsync("alert", errorMessage);
            }
        }

        private async Task ConfirmCommentAsync(Comment comment)
        {
            if (!comment.Verified)
            {
                comment.Verified = true;
                dbContext.Comments.Update(comment);
                if (await dbContext.SaveChangesAsync() > 0)
                {
                    reload();
                }
                else
                {
                    string errorMessage = "ERROR: Failed to confirm comment";
                    await JsRuntime.InvokeVoidAsync("alert", errorMessage);
                }
            }
           
        }

        private void reload()
        {
            NavManager.NavigateTo("/Offers/" + offer.Id + "/Comments");
        }
    }
}