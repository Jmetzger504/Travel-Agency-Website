using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExcelsiorAPI.Models.EF;
using System.Data.Entity;

namespace ExcelsiorAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VoyageController : ControllerBase
  {
    excelsiorDbContext dbContext = new excelsiorDbContext();

    [HttpGet]
    [Route("Voyages")]
    public IActionResult getVoyages()
    {
      try
      {
        var voyages = dbContext.Voyages;
        return Ok(voyages);
      }
      catch (Exception ex) { throw new Exception(ex.Message); }
    }
  }
}
