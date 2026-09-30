using Autik.Application.Interfaces;
using Autik.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Autik.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TallerController:ControllerBase
{
    private readonly ITallerRepository _repository;
    
    public TallerController(ITallerRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> getTalleres()
    {
        var taller = await _repository.GetAllAsync();
        return Ok(taller);
    }

    [HttpPost]
    public async Task<IActionResult> PostTaller([FromBody] Taller taller)
    {
        if (string.IsNullOrWhiteSpace(taller.Nombre))
        {
            return BadRequest("El nombre del taller es obligatorio");
        }
        
        var nuevoTaller = await _repository.AddAsync(taller);
        
        return CreatedAtAction(nameof(getTalleres), new { id = nuevoTaller.Id }, nuevoTaller);
    }
    
}