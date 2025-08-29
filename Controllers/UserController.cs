using Microsoft.AspNetCore.Mvc;
using userMan.Models;

namespace userMan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    // Dictionary for fast ID lookups
    private static Dictionary<int, User> _users = new();
    private static int _nextId = 1;

    // GET api/user
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        // Return all users (could add paging later)
        return Ok(_users.Values);
    }

    // GET api/user/{id}
    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        if (!_users.TryGetValue(id, out var user))
            return NotFound(new { message = $"User with ID {id} not found" });

        return Ok(user);
    }

    // POST api/user
    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        user.Id = _nextId++;
        _users[user.Id] = user;

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // PUT api/user/{id}
    [HttpPut("{id}")]
    public ActionResult<User> UpdateUser(int id, User updatedUser)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (!_users.TryGetValue(id, out var existingUser))
            return NotFound(new { message = $"User with ID {id} not found" });

        existingUser.FirstName = updatedUser.FirstName;
        existingUser.LastName = updatedUser.LastName;
        existingUser.Email = updatedUser.Email;
        existingUser.Department = updatedUser.Department;

        return Ok(existingUser);
    }

    // DELETE api/user/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        if (!_users.ContainsKey(id))
            return NotFound(new { message = $"User with ID {id} not found" });

        _users.Remove(id);
        return NoContent();
    }
}