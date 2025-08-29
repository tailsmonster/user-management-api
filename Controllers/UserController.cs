using Microsoft.AspNetCore.Mvc;
using userMan.Models;

namespace userMan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    // In-memory list (ideally we'd replace this with a DB)
    private static List<User> _users = new List<User>();
    
    // GET api/users
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<User>> GetUsers() => Ok(_users);
    
    // GET api/users/{id}
    [HttpGet("{id}")]
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        return user == null ? NotFound() : Ok(user);
    }
    
    // POST
    [HttpPost]
    {
        user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
        
    }
}