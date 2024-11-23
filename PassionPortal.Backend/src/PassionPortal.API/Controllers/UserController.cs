using Domain.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassionPortal.Infrastracture;

namespace PassionPortal.API.Controllers;

public class UserController : BaseApiController
{
    private readonly DatingAppDbContext _context;
    public UserController(DatingAppDbContext context)
    {
        _context = context;
    }

    [HttpGet("List")]
    public async Task<ActionResult<IEnumerable<User>>> List()
    {
        var listUsers = await _context.Users.ToListAsync();

        return Ok(listUsers);
    }

    [HttpGet("GetById/{id:long}")]
    public async Task<ActionResult<User>> GetById(long id)
    {
        var user = await _context.Users.FindAsync(id);
        
        if (user is not null) 
            return Ok(user);
        else 
            return NotFound();
    }
}