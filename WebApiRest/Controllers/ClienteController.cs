using Microsoft.AspNetCore.Mvc;
using WebApiRest.Model;

namespace WebApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController :  ControllerBase
    {

        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {
            List<Cliente> clientes = new List<Cliente>
            {
            new Cliente
                {
                    id = 1,
                    nombre = "Paolo",
                    edad = "25",
                    correo = "lalola@mail.com"
                },
                new Cliente
                {
                    id = 2,
                    nombre = "Zurdo",
                    edad = "23",
                    correo = "lazozo@mail.com"
                }
            };
            return clientes;
        }




        [HttpGet]
        [Route("cliente")]
        public dynamic getCliente(int id)
        {
            return Ok();
        }



        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            return Ok();
        }


        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarCliente(int id)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

            if (token != "321321321")
            {
                return new
                {
                    success = false,
                    message = "error con el token",
                    result = id
                };
            }
            return new
            {
                success = true,
                message = "borrado exitoso",
                result = id
            };
        }


    }
}
