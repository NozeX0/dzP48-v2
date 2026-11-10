using Microsoft.AspNetCore.Mvc; using Microsoft.EntityFrameworkCore; using dz_8.Data; using dz_8.Models;
namespace dz_8.Controllers
{
    [Route("api/tasks")] [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context; public TasksController(AppDbContext context) { _context = context; }
        [HttpGet]
        public async Task<IActionResult> GetTasks([FromQuery] bool? completed, [FromQuery] bool? expired, [FromQuery] bool? current)
        {
            var query = _context.Tasks.AsQueryable();
            if (completed == true) query = query.Where(t => t.Completed);
            if (expired == true) query = query.Where(t => t.Deadline_date < DateTime.UtcNow && !t.Completed);
            if (current == true) query = query.Where(t => t.Deadline_date >= DateTime.UtcNow && !t.Completed);
            return Ok(new ApiResponse<IEnumerable<TaskItem>> { Status = 200, Message = "Ok", Data = await query.ToListAsync() });
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateTask([FromBody] TaskItem task, [FromHeader(Name = "Authorization")] string? token)
        {
            if (string.IsNullOrEmpty(token)) return StatusCode(403, new ApiResponse<object> { Status = 403, Message = "Forbidden" });
            if (task == null || string.IsNullOrEmpty(task.Title)) return BadRequest(new ApiResponse<object> { Status = 400, Message = "Invalid data" });
            task.Id = Guid.NewGuid(); _context.Tasks.Add(task); await _context.SaveChangesAsync();
            return Ok(new ApiResponse<TaskItem> { Status = 200, Message = "Created", Data = task });
        }
    }
}
