using Autik.Application.Interfaces;
using Autik.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Autik.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VehiculoController:ControllerBase
{
    private readonly IVehiculoRepository _repository;

    //inyeccion de dependencias
    public VehiculoController(IVehiculoRepository repository)
    {
        _repository = repository;
    }


    [HttpGet]
    public async Task<IActionResult> getVehiculos()
    {
        var vehiculos = _repository.GetAllAsync();
        return Ok(vehiculos);
    }


    [HttpPost]
    public async Task<IActionResult> CrearVehiculo([FromBody] Vehiculo vehiculo)
    {
        if (string.IsNullOrWhiteSpace(vehiculo.Descripcion)) {
            return BadRequest("la descripcion del vehiculo es obligatoria."); // HTTP 400 Bad Request
        }

        var nuevoVehiculo = await _repository.AddAsync(vehiculo);
        
        // HTTP 201 Created: Devuelve el recurso recién creado por cortesía RESTful
        return CreatedAtAction(nameof(getVehiculos), new { id = nuevoVehiculo.Id }, nuevoVehiculo);
    }
    
}