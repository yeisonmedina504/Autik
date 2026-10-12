using Autik.Application.Features.Mantenimiento.DTOs;
using Autik.Application.Interfaces;
using Autik.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Autik.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MantenimientoController: ControllerBase
{
    private readonly IMantenimientoRepository _repository;
    private readonly IValidator<CreateMantenimientoRequestDto> _validator;
    private readonly IValidator<UpdateMantenimientoRequestDto> _updateValidator;
    
    
    public  MantenimientoController(IMantenimientoRepository repository, IValidator<CreateMantenimientoRequestDto> validator, IValidator<UpdateMantenimientoRequestDto> updateValidator)
    {
        _repository = repository;
        _validator = validator;
        _updateValidator = updateValidator;
    }
    
    
    //controller @GetAllMantenimientos
    [HttpGet]
    public async Task<IActionResult> GetMantenimientos()
    {
        var mantenimientos = await _repository.GetAllAsync();
        var response = mantenimientos.Select(m => new MantenimientoResponseDto
        {
            Id = m.Id,
            Tipo = m.Tipo,
            MarcaModelo =  m.MarcaModelo,
            Placa = m.Placa,
            Anio = m.Anio
        });
        
        return Ok(response);
    }

    
    
    //controller PostMantenimientos
    [HttpPost]
    public async Task<IActionResult> PostMantenimiento([FromBody] CreateMantenimientoRequestDto request)
    {
        // 1. Ejecutar FluentValidation
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);// HTTP 400 automático con detalles
        }
        
        // 2. Mapeo Manual: DTO -> Entidad (Solo transferimos lo permitido)
        var nuevoMantenimiento = new Mantenimiento
        {
            Tipo = request.Tipo,
            MarcaModelo = request.MarcaModelo,
            Placa = request.Placa,
            Anio = request.Anio
        };
        
        // 3. Persistencia
        var mantenimientoCreado = await _repository.AddAsync(nuevoMantenimiento);
        
        // 4. Mapeo de Retorno
        var response = new MantenimientoResponseDto
        {
            Id = mantenimientoCreado.Id,
            Tipo = mantenimientoCreado.Tipo,
            MarcaModelo = mantenimientoCreado.MarcaModelo,
            Placa = mantenimientoCreado.Placa,
            Anio = mantenimientoCreado.Anio
        };

        return CreatedAtAction(nameof(GetMantenimientos), new { id = response.Id }, response);
    }


    //Controller @GetMantenimientoById
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMantenimientoById(int id)
    {
        
        var mantenimiento = await _repository.GetByIdAsync(id);
        if (mantenimiento == null)
            return NotFound();

        var response = new MantenimientoResponseDto 
        {
            Id = mantenimiento.Id,
            Tipo = mantenimiento.Tipo,
            MarcaModelo = mantenimiento.MarcaModelo,
            Placa = mantenimiento.Placa,
            Anio = mantenimiento.Anio
        };

        return Ok(response);
                
    }
    
    
    //controller PutMantenimientos
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutMantenimiento(int id, [FromBody] UpdateMantenimientoRequestDto request)
    {
        if (id != request.Id)
            return BadRequest("El Id de la ruta no coincide con el Id del cuerpo.");

        var validationResult = await _updateValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var existente = await _repository.GetByIdAsync(id);
        if (existente == null)
            return NotFound();

        var entidad = new Mantenimiento
        {
            Id = request.Id,
            Tipo = request.Tipo,
            MarcaModelo = request.MarcaModelo,
            Placa = request.Placa,
            Anio = request.Anio
        };

        var actualizado = await _repository.UpdateAsync(entidad);

        var response = new MantenimientoResponseDto
        {
            Id = actualizado.Id,
            Tipo = actualizado.Tipo,
            MarcaModelo = actualizado.MarcaModelo,
            Placa = actualizado.Placa,
            Anio = actualizado.Anio
        };

        return Ok(response);
    }

    //controller DeleteMantenimiento
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMantenimiento(int id)
    {
        var eliminado = await _repository.DeleteAsync(id);
        if (eliminado == null)
            return NotFound();

        return NoContent();  // 204: eliminado OK, sin cuerpo
    }
    
    
    
}