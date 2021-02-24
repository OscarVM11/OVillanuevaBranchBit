using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class ProductoController : ApiController
    {
        // GET: api/Producto
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Producto/5
        [HttpGet]
        [Route("api/Producto/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Producto.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Producto        
        [HttpPost]
        [Route("api/Producto/Add")]
        public IHttpActionResult Post([FromBody]ML.Producto producto)
        {

            ML.Result result = BL.Producto.Add(producto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }

        // PUT: api/Producto/5        
        [HttpPut]
        [Route("api/Producto/Update")]
        public IHttpActionResult Put([FromBody]ML.Producto producto)
        {
            var result = BL.Producto.Update(producto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Producto/5        
        [HttpDelete]
        [Route("api/Producto/Delete/{sku}")]        
        public IHttpActionResult Delete(string SKU)
        {
            ML.Producto producto = new ML.Producto();
            producto.SKU = SKU;
            var result = BL.Producto.Delete(SKU);
 
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/Producto/Login")]
        public IHttpActionResult Loggin([FromBody] ML.Usuario usuario)
        {
           
            if (usuario.UserName=="UsuarioTest" && usuario.Password=="123456") //colocar por defecto un usuario y password para ver si estan logueados correctamente
            {                
                    var token = Token.GenerateTokenJwt(usuario.UserName);
                    return Ok(token); //en caso de estar autorizado genera el token                           
            }
            else
            {
                return Unauthorized();
            }
        }
    }

}
