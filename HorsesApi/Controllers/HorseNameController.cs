using System.Net;
using System.Security.Cryptography;
using HorsesApi.Models;
using HorsesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HorsesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HorseNameController : Controller
{
    private readonly BusinessProvider _business;

    public HorseNameController(BusinessProvider business)
    {
        _business = business;
    }

    [HttpGet("{type}")]
    [ProducesResponseType(typeof(HorseName), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Get(int type)
    {
        string? choice = null;
        
        switch (type)
        {
            case 0 : choice = "n."; break;
            case 1 : choice = "pl."; break;
            case 2 : choice = "a."; break;
            case 3 : choice = "v."; break;
            case 4 : choice = "imp."; break;
            case 5 : choice = "adv."; break;
            case 6 : choice = "pr."; break;
            case 7 : choice = "vb."; break;
        }

        return Ok(await _business.GetName(choice));
    }
}