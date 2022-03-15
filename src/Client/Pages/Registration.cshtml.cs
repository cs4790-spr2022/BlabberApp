using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Common.Interfaces;
using BlabberApp.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages;

public class RegistrationModel : PageModel
{
    [BindProperty]
    public string? FirstName { get; set; }
    [BindProperty]
    public string? LastName { get; set; }
    [BindProperty]
    public string? Email { get; set; }
    [BindProperty]
    public string? Username { get; set; }
    private ILogger<RegistrationModel> log;
    private IUserRepository repo;
    public RegistrationModel(ILogger<RegistrationModel> logger, IUserRepository repository)
    {
        log = logger;
        repo = repository;
        log.LogInformation("Injected the repo");
    }

    public void OnGet()
    { }
    public void OnPost()
    {
        User user = new User(Username.ToString(), Email.ToString());
        user.FirstName = FirstName;
        user.LastName = LastName;

        repo.Add(user);

        log.LogInformation("Add user into repo");

        IEnumerable<User> users = repo.GetAll();
        foreach (var u in users)
        {
            log.LogInformation(u.Username + ", " + u.Email);
        }
    }
}