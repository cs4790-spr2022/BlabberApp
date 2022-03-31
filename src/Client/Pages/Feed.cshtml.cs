using Domain.Common.Interfaces;
using Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages;
public class FeedModel : PageModel
{
    [BindProperty] public List<Blab> Blabs { get; set; }
    [BindProperty] public string? Message { get; set; }
    [BindProperty] public string? Username { get; set; }
    private readonly ILogger<FeedModel> _log;
    private readonly IBlabRepository _repo;
    public FeedModel(ILogger<FeedModel> logger, IBlabRepository repository)
    {
        _log = logger;
        _repo = repository;
        Blabs = new List<Blab>();
        _log.LogInformation("Injected the repository");
    }
    public void OnGet()
    {
        Blabs = (List<Blab>) _repo.GetAll();
        Blabs = Blabs.OrderByDescending(b => b.DttmCreated).ToList();
    }

    public void OnPost()
    {
        Blab b = new(Message, Username) {DttmCreated = DateTime.Now, DttmModified = DateTime.Now};
        // b.Validate();
        _repo.Add(b);
    }
}