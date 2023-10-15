using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaPerformance.Data;
using MinhaPerformance.Dtos;

namespace MinhaPerformance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicationUserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ApplicationUserController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ApplicationUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUserDto>>> GetUsers()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_context.Users == null)
            {
                return NotFound();
            }
            var _user = await _context.Users.Where(u => u.Id != currentUserId).ToListAsync();

            return _mapper.Map<List<ApplicationUserDto>>(_user);
        }
    }
}
