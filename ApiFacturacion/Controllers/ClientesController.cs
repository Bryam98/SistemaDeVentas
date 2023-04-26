using ApiFacturacion.DTOS;
using ApiFacturacion.Models;
using ApiFacturacion.Models.Context;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicactionDbContext _dbContext;
        private readonly IMapper mapper;

        public ClientesController(ApplicactionDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet("ListadoClientes")]
        public async Task<List<ClienteDTO>> ListadoClientes()
        {
            var clientes = await _dbContext.Cliente.Take(10).ToListAsync();

            return mapper.Map<List<ClienteDTO>>(clientes);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClienteDTO>> GetPorId([FromRoute] int id)
        {
            var cliente = await _dbContext.Cliente.FirstOrDefaultAsync(x => x.Id == id);

            if (cliente is null)
            {
                return BadRequest("Error no existe ningun cliente con ese id");
            }

            return mapper.Map<ClienteDTO>(cliente);

        }
        [HttpGet("{nombre}")]
        public async Task<ActionResult<ClienteDTO>> GetPorNombre([FromRoute] string nombre)
        {
            var cliente = await _dbContext.Cliente.FirstOrDefaultAsync(x => x.Nombres == nombre);

            if (cliente is null)
            {
                return BadRequest("Error no existe ningun cliente con ese nombre");
            }

            return mapper.Map<ClienteDTO>(cliente);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteCreacionDTO clienteCreacionDTO)
        {

            var clienteExiste = await _dbContext.Cliente.AnyAsync(x => x.Cedula == clienteCreacionDTO.Cedula);

            if (clienteExiste)
            {

                return BadRequest($"Ya existe un cliente con el numero de cedula {clienteCreacionDTO.Cedula} en la bd ");

            }

            var cliente = mapper.Map<Cliente>(clienteCreacionDTO);

            _dbContext.Add(cliente);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("ListadoClientes");
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ClienteCreacionDTO clienteCreacionDTO)
        {
            var clienteExiste = await _dbContext.Cliente.AnyAsync(x => x.Id == id);

            if (!clienteExiste)
            {

                return BadRequest($"no existe un cliente con el id indicado");

            }

            var cliente = mapper.Map<Cliente>(clienteCreacionDTO);
            cliente.Id = id;

            _dbContext.Update(cliente);
            await _dbContext.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var clienteExiste = await _dbContext.Cliente.AnyAsync(x => x.Id == id);

            if (!clienteExiste)
            {

                return BadRequest($"no existe un cliente con el id indicado");

            }

            _dbContext.Remove(new Cliente() { Id = id });
            await _dbContext.SaveChangesAsync();

            return NoContent();

        }

    }
}
