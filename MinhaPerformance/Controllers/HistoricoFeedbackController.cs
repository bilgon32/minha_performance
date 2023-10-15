using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaPerformance.Data;
using MinhaPerformance.Dtos;
using MinhaPerformance.Models;

namespace MinhaPerformance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoricoFeedbackController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public HistoricoFeedbackController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        // GET: api/HistoricoFeedback
        [HttpGet("recebidos")]
        public async Task<ActionResult<IEnumerable<HistoricoFeedbackDto>>> GetHistoricoFeedbacksRecebidos()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(currentUserId))
                return Unauthorized();

            if (_context.HistoricoFeedbacks == null)
            {
                return NotFound();
            }
            var list = await _context.HistoricoFeedbacks
                                    .Where(hf => hf.Receptor.Id == currentUserId)
                                    .Include(hf => hf.Provedor)
                                    .Include(hf => hf.Feedback)
                                    .ToListAsync();

            return _mapper.Map<List<HistoricoFeedbackDto>>(list);
        }

        // GET: api/HistoricoFeedback
        [HttpGet("enviados")]
        public async Task<ActionResult<IEnumerable<HistoricoFeedbackDto>>> GetHistoricoFeedbacksEnviados()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(currentUserId))
                return Unauthorized();

            if (_context.HistoricoFeedbacks == null)
            {
                return NotFound();
            }
            var list = await _context.HistoricoFeedbacks
                                    .Where(hf => hf.Provedor.Id == currentUserId)
                                    .Include(hf => hf.Receptor)
                                    .Include(hf => hf.Feedback)
                                    .ToListAsync();

            return _mapper.Map<List<HistoricoFeedbackDto>>(list);
        }

        // GET: api/HistoricoFeedback/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoFeedbackDto>> GetHistoricoFeedback(string id)
        {
            if (_context.HistoricoFeedbacks == null)
            {
                return NotFound();
            }
            var historicoFeedback = await _context.HistoricoFeedbacks
                                                    .Include(hf => hf.HistoricoFeedbackCriterios)
                                                        .ThenInclude(hfc => hfc.Criterio)
                                                    .Include(hf => hf.Provedor)
                                                    .Include(hf => hf.Receptor)
                                                    .Include(hf => hf.Feedback)
                                                    .FirstOrDefaultAsync();

            if (historicoFeedback == null)
            {
                return NotFound();
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(currentUserId))
                return Unauthorized();

            if (historicoFeedback.Provedor.Id != currentUserId && historicoFeedback.Receptor.Id != currentUserId)
                return Unauthorized();

            return _mapper.Map<HistoricoFeedbackDto>(historicoFeedback);
        }

        // POST: api/HistoricoFeedback
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistoricoFeedbackDto>> PostHistoricoFeedback(CreateHistoricoFeedbackDto dto)
        {
            if (_context.HistoricoFeedbacks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HistoricoFeedbacks'  is null.");
            }

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(currentUserId))
                return Unauthorized();

            var entity = _mapper.Map<HistoricoFeedback>(dto);

            entity.Id = Guid.NewGuid().ToString();
            entity.Provedor = await _context.Users.FindAsync(currentUserId);
            entity.Receptor = await _context.Users.FindAsync(dto.ReceptorId);
            entity.Feedback = await _context.Feedbacks.FindAsync(dto.FeedbackId);
            entity.HistoricoFeedbackCriterios = new List<HistoricoFeedbackCriterio>();

            foreach (var criterioDto in dto.HistoricoFeedbackCriterios)
            {
                var criterioEntity = _mapper.Map<HistoricoFeedbackCriterio>(criterioDto);
                criterioEntity.Id = Guid.NewGuid().ToString();
                criterioEntity.Criterio = await _context.Criterios.FindAsync(criterioDto.CriterioId);
                entity.HistoricoFeedbackCriterios.Add(criterioEntity);
            }

            _context.HistoricoFeedbacks.Add(entity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HistoricoFeedbackExists(entity.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHistoricoFeedback", new { id = entity.Id }, dto);
        }

        private bool HistoricoFeedbackExists(string id)
        {
            return (_context.HistoricoFeedbacks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
