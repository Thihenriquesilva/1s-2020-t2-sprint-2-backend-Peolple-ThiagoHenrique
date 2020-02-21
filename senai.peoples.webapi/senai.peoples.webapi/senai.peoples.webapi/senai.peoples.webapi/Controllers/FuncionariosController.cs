using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.peoples.webapi.Domains;
using senai.peoples.webapi.Interfaces;
using senai.peoples.webapi.Repositories;

namespace senai.peoples.webapi.Controllers
{[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionarioRepository _funcRepository { get; set; }

        public FuncionariosController()
        {
            _funcRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionariosDomain> Get()
        {
            return _funcRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(FuncionariosDomain fu)
        {
            _funcRepository.AdicionarFuncionario(fu);

            return Ok("Cadastrado com Sucesso");
        }

        [HttpGet("{id}")]

        public IActionResult GETPorId(int id)
        {
            FuncionariosDomain funcBuscado = _funcRepository.BuscarPorId(id);

            if (funcBuscado == null)
            {
                return NotFound("Nenhum funcionário foi encontrado");
            }

            return Ok(funcBuscado);

        }

        [HttpGet("buscar/{nome}")]
        
        public IActionResult GETPorNome(string nome)
        {
            FuncionariosDomain funcNomeBuscar = _funcRepository.BuscarPorNome(nome);

            if(funcNomeBuscar == null)
            {
                return NotFound("Nenhum funcionário foi encontrado");
            }
            return Ok(funcNomeBuscar);
        }


        [HttpPut]
        public IActionResult AtualizarCorpo(FuncionariosDomain funcionario)
        {
            FuncionariosDomain buscarPorID = _funcRepository.BuscarPorId(funcionario.IdFuncionario);

            if (funcionario != null)
            {
                try
                {

                    _funcRepository.AtualizarPorIdCorpo(funcionario);

                    return NoContent();

                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return NotFound(
                new
                {
                    mensagem = "Funcionário não encontrado",
                    e = true
                }
            );
        }
 


        [HttpPut("{id}")]

        public IActionResult AtualizarById(int id, FuncionariosDomain funcionario)
        {
            FuncionariosDomain buscarPorID = _funcRepository.BuscarPorId(id);

            if (buscarPorID == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Funcionario não encontrado",
                        erro = true
                    }
                );

            }

            try
            {
                _funcRepository.AtualizarPorIdUrl(id, funcionario);

                return NoContent();
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _funcRepository.Deletar(id);

            return Ok("Comando executado com Sucesso");
        }
    }

}