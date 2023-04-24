using first_dotnet_proj.Data;
using first_dotnet_proj.Models;
using Microsoft.AspNetCore.Mvc;

namespace first_dotnet_project.Controllers;

[Route(template: "api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{


    private static AppDbContext _context;
    public TeamsController(AppDbContext context){
        _context = context;
    }
    private static List<Team> teams = new List<Team>(){
        new Team(){
            Country = "Germany",
            Name = "Honda",
            Id = 1,
            TeamPrinciple = "kelel"
        },
        new Team(){
            Country = "France",
            Name = "Honda",
            Id = 2,
            TeamPrinciple = "kelel"
        },
        new Team(){
            Country = "Spain",
            Name = "Honda",
            Id = 3,
            TeamPrinciple = "kelel"
        }
    };

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(teams);
    }

    [HttpGet(template:"{id:int}")]
    public IActionResult Get(int id){
    
        var team = teams.FirstOrDefault(x => x.Id == id);
        if (team ==null)
            return BadRequest(error:"Invalid id");
        
        return Ok(team);
    }

    [HttpPost]
    public IActionResult Post(Team team){
        teams.Add(team);
        return CreatedAtAction("Get", routeValues:team.Id, value:team);
    }

    [HttpPatch]
    public IActionResult Patch (int id, string country){
        var team = teams.FirstOrDefault(x => x.Id ==id);
        if (team == null)
            return BadRequest(error:"Invalid Id");
        team.Country = country;
        return NoContent();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var team = teams.FirstOrDefault(x => x.Id == id);
        if (team == null)
            return BadRequest(error: "Invalid Id");
        teams.Remove(team);
        return NoContent();
    }
}