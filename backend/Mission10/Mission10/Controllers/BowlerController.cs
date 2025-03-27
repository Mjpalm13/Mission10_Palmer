using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10.Models;

namespace Mission10.Controllers;
// Create the controller that will be displayed at the route you decide
[Route("bowler")]
[ApiController]
public class BowlerController : Controller
{
    // Establish the _context to represent the data in the database
    private BowlingLeagueContext _context;

    public BowlerController(BowlingLeagueContext context)
    {
        _context = context;
    }
    
    // Create a BowlerDTO object constructor to mesh together data from the bowler table and the teams table
    public class BowlerDTO
    {
        public int BowlerId { get; set; }
        public string? BowlerFirstName { get; set; }
        public string? BowlerLastName { get; set; }
        public string? BowlerMiddleInit { get; set; }
        public string? BowlerAddress { get; set; }
        public string? BowlerCity { get; set; }
        public string? BowlerState { get; set; }
        public string? BowlerZip { get; set; }
        public string TeamName { get; set; } // This is NOT in the scaffolded model
    }

    // When the route is called, get the bowler information from _context
    [HttpGet(Name = "GetBowlers")]
    public ActionResult<IEnumerable<Bowler>> Get()
    {
        var bowlerList = _context.Bowlers
            .Include(x => x.Team)
            .Where(x => x.TeamId == 1 || x.TeamId == 2)
            .Select(x => new BowlerDTO // Use the BowlerDTO object to smoothly combine data from two tables and display them together
            {
                BowlerId = x.BowlerId,
                BowlerFirstName = x.BowlerFirstName,
                BowlerLastName = x.BowlerLastName,
                BowlerMiddleInit = x.BowlerMiddleInit,
                BowlerAddress = x.BowlerAddress,
                BowlerCity = x.BowlerCity,
                BowlerState = x.BowlerState,
                BowlerZip = x.BowlerZip,
                TeamName = x.Team.TeamName // Only include the TeamName
            })
            .ToList();
        // Return the data for usage
        return Ok(bowlerList);
    }

}