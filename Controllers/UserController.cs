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
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers() => Ok(_users);
    
    // GET api/users/{id}
    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        return user == null ? NotFound() : Ok(user);
    }
    
    // POST api/users
    [HttpPost] 
    public ActionResult<User> CreateUser(User user)
    {
        user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
        _users.Add(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }
    
    // PUT api/users/{id}
    [HttpPut("{id}")]
    public ActionResult<User> UpdateUser(int id, User updatedUser)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();
        user.FirstName = updatedUser.FirstName;
        user.LastName = updatedUser.LastName;
        user.Email = updatedUser.Email;
        user.Department = updatedUser.Department;
        return Ok(user);
    }
    
    // DELETE api/users/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();
        _users.Remove(user);
        return NoContent();
    }
}