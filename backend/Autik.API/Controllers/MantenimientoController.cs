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
    public  MantenimientoController(IMantenimientoRepository repository, IValidator<CreateMantenimientoRequestDto> validator)
    {
        _repository = repository;
        _validator = validator;
    }
    
    

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
    
}