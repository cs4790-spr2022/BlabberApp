using System.ComponentModel.DataAnnotations;

using Domain.Common.Interfaces;
using Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages;

public class BlabModel : PageModel
{
    [BindProperty, Required] public string UserNameInput { get; set; }

    [BindProperty, MaxLength(100), Required]
    public string BlabInput { get; set; }

    private readonly ILogger<BlabModel> _log;
    private readonly IBlabRepository _repo;

    public BlabModel(ILogger<BlabModel> logger, IBlabRepository repository, IUserRepository userRepo)
    {
        _log = logger;
        _repo = repository;
        _log.LogInformation("Injected the repository");
        UserNameInput = "";
        BlabInput = "";
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // otherwise do some proc
        try
        {
            var user = _userRepo.GetByUsername(bDto.Username);
        }
        catch (Exception e)
        {
            throw new BadHttpRequestException(e.Message);
        }essing
        Blab blab = new(BlabInput, UserNameInput);
        _repo.Add(blab);
        _log.LogInformation("Added Blab: " + blab.Id.ToString());
        return RedirectToPage("./Blab");
    }
}