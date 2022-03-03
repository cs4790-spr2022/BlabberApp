using System;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Common.Interfaces;
using BlabberApp.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlabberApp.Namespace
{
    public class RegistrationModel : PageModel
    {
        private User _user;
        public void OnGet()
        { }

        public void OnPostSubmit(UserModel usr)
        {
            _user = new User(usr.Username, usr.Email);
            _user.FirstName = usr.FirstName;
            _user.LastName = usr.LastName;
        }
    }

}