using Autik.Application.Interfaces;
using Autik.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Autik.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MantenimientoController: ControllerBase
{
    private readonly IMantenimientoRepository _repository;
    public  MantenimientoController(IMantenimientoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetMantenimientos()
    {
        var mantenimientos = _repository.GetAllAsync();
        return Ok(mantenimientos);
    }

    [HttpPost]
    public async Task<IActionResult> PostMantenimiento([FromBody] Mantenimiento mantenimiento)
    {
        if (string.IsNullOrWhiteSpace(mantenimiento.MarcaModelo))
        {
            return BadRequest("La marc y modelo son obligatorias");
        }
        
        var nuevoMantenimiento = _repository.AddAsync(mantenimiento);
        
        return CreatedAtAction(nameof(GetMantenimientos),  new { id = nuevoMantenimiento.Id }, nuevoMantenimiento);
    }
    
}