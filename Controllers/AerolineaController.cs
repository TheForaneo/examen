using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Sqlite;
using examen.Models;
using Dapper;
using Microsoft.Data.Sqlite;
using MongoDB.Driver;
using Examen;

namespace examen.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class AerolineaController : Controller{
        private readonly AerolineaService _aerolineaService;
        public AerolineaController(AerolineaService aerolineaService){
           _aerolineaService=aerolineaService;
        }

        [HttpGet]
        public ActionResult<List<Aerolinea>> LeerTodos(){
            return _aerolineaService.Get();  
        }

        [HttpGet("{Isd}", Name="Get")]
        [Route("action")]
        public ActionResult<Aerolinea> LeerPorId(int id){  
            var aerolinea= _aerolineaService.GetId(id);
            if(aerolinea != null){
                return aerolinea;
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Aerolinea> Crear(Aerolinea aero){
            _aerolineaService.Create(aero);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, Aerolinea update)
        {   
            var aerolinea = _aerolineaService.GetId(id);
            if(aerolinea != null){
                if(_aerolineaService.Update(id, update)){
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int Id){
            var aerolinea = _aerolineaService.GetId(Id);
            if(aerolinea!=null){
                _aerolineaService.Remove(aerolinea.Isd);
                return Ok();
            }
            return NotFound();
            
        }


    }
}
