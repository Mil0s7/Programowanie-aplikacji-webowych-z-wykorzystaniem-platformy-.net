using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.DTOs;

namespace TaskManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    // Magazyn danych w pamięci aplikacji
    private static List<TaskItem> _tasks = new List<TaskItem>
    {
        new TaskItem { Id = 1, Title = "Zrobić Etap I", Description = "Modele, DTO, kontroler", IsCompleted = false, UserId = 1 },
        new TaskItem { Id = 2, Title = "Napisać README", Description = "Opis projektu", IsCompleted = true, UserId = 1 }
    };

    // GET: api/tasks (wszystkie zadania jako DTO)
    [HttpGet]
    public ActionResult<IEnumerable<TaskDto>> GetAll()
    {
        var dtos = _tasks.Select(t => new TaskDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            IsCompleted = t.IsCompleted,
            DueDate = t.DueDate
        });
        return Ok(dtos);
    }

    // GET: api/tasks/{id} (jedno zadanie po Id)
    [HttpGet("{id}")]
    public ActionResult<TaskDto> GetById(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return NotFound("Nie znaleziono takiego zadania!");

        var dto = new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            DueDate = task.DueDate
        };
        return Ok(dto);
    }

    // POST: api/tasks (dodaj nowe zadanie)
    [HttpPost]
    public ActionResult Create(CreateTaskDto dto)
    {
        var newId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;

        var newTask = new TaskItem
        {
            Id = newId,
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            IsCompleted = false,
            UserId = 1 // na razie na sztywno
        };

        _tasks.Add(newTask);
        return CreatedAtAction(nameof(GetById), new { id = newId }, dto);
    }
}