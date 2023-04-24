using first_dotnet_proj.Data;
using first_dotnet_proj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace first_dotnet_project.Controllers;

[Route(template: "api/[controller]")]
[ApiController]
public class teamsController : ControllerBase
{


    private static AppDbContext _context;
    public teamsController(AppDbContext context){
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var teams = await _context.teams.ToListAsync();
        return Ok(teams);
    }

    [HttpGet(template:"{id:int}")]
    public async Task<IActionResult> Get(int id){
    
        var team = await _context.teams.FirstOrDefaultAsync(x => x.Id == id);
        if (team ==null)
            return BadRequest(error:"Invalid id");
        
        return Ok(team);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Team team){
        await _context.teams.AddAsync(team);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Get", routeValues:team.Id, value:team);
    }

    [HttpPatch(template: "{id:int}")]
    public async Task<IActionResult> Patch (int id, string country){
        var team = await _context.teams.FirstOrDefaultAsync(x => x.Id ==id);
        if (team == null)
            return BadRequest(error:"Invalid Id");
        team.Country = country;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete (template:"{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var team = await _context.teams.FirstOrDefaultAsync(x => x.Id == id);
        if (team == null)
            return BadRequest(error: "Invalid Id");
        _context.teams.Remove(team);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}