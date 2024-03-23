using DateAccess.Date;
using DateAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Task.home3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public readonly TaskDbContext _dbContext;

        public TaskController(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("tasks")]
        public async Task<IActionResult> GetAll() 
        {
            var tasks = await _dbContext.Tasks.ToListAsync();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(x=>x.Id==id);

            return Ok(task);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TaskEntity taskEntity)
        {

            await _dbContext.Tasks.AddAsync(taskEntity);

            await _dbContext.SaveChangesAsync();

            return Ok(taskEntity);
        }

        //HttpPut метод для редагування
        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] TaskEntity taskEntity)
        {            
            var existingTask = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskEntity.Id); // Знаходимо об'єкт для редагування за його ідентифікатором

           // Застосовуємо зміни до існуючого об'єкта
            existingTask.Name = taskEntity.Name;
            existingTask.Description = taskEntity.Description;            

            _dbContext.Tasks.Update(existingTask); // Позначаємо об'єкт як змінений
            await _dbContext.SaveChangesAsync(); // Зберігаємо зміни у базі даних

            return Ok(); // Повертаємо змінений об'єкт разом з кодом 200 OK
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var taskToDelete = await _dbContext.Tasks.FindAsync(id); // Знаходимо об'єкт для видалення за його ідентифікатором

            if (taskToDelete == null)
            {
                return NotFound(); // Повертаємо код 404 Not Found, якщо об'єкт не знайдено
            }

            _dbContext.Tasks.Remove(taskToDelete); // Позначаємо об'єкт для видалення
            await _dbContext.SaveChangesAsync(); // Зберігаємо зміни у базі даних

            return Ok(taskToDelete); // Повертаємо видалений об'єкт разом з кодом 200 OK
        }
    }
}
