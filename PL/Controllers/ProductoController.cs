using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            //ML.Result result = BL.Producto.GetAll();
            ML.Result result = BL.Producto.GetAllByAPI();

            producto.Productos = result.Objects;
            return View(producto);
        }

        [HttpGet]
        public ActionResult Form(string SKU)
        {

            ML.Result resultTipos = BL.Tipo.GetAll();

            ML.Producto producto = new ML.Producto();

            producto.Tipo = new ML.Tipo();
            producto.Tipo.Tipos = resultTipos.Objects;

            if (SKU==null)
            {
                producto.Accion = "Add";
                ViewBag.Titulo = "Agregar producto nuevo";
                ViewBag.Accion = "Guardar";

                return View(producto);
            }
            else
            {
                producto.Accion = "Update";
                ViewBag.Titulo = "Actualizar producto existente";
                ViewBag.Accion = "Actualizar";
                producto.SKU = SKU;
                var result = BL.Producto.GetBySKU(producto.SKU);
                producto = (ML.Producto)result.Object;

                producto.Tipo.Tipos = resultTipos.Objects;

                return View(producto);
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            if (producto.Accion=="Add")
            {
                
                //result = BL.Producto.Add(producto);
                result = BL.Producto.AddByAPI(producto);

                if (result.Correct)
                {
                    ViewBag.Message = "Se agrego correctamente";
                    return PartialView("ValidationModal");
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al agregar.  Error: " + result.ErrorMessage;
                    return PartialView("ValidationModal");
                }
            }
            else
            {
                
                 result = BL.Producto.UpdateByApi(producto); //ejemploComentario

                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente. ";
                    return PartialView("ValidationModal");
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al actualizar.  Error: " + result.ErrorMessage;
                    return PartialView("ValidationModal");
                }
            }
        }
        [HttpGet]
        public ActionResult Delete(string SKU)
        {
            //ML.Result result = BL.Producto.Delete(SKU)
            ML.Result result = BL.Producto.DeleteByAPI(SKU);
            if (result.Correct)
            {

                ViewBag.Message = "Eliminado correctamente";

            }
            else
            {

                ViewBag.Message = "Ocurrió un error al eliminar. " + result.ErrorMessage;

            }
            return PartialView("ValidationModal");
        }//Delete

        public ActionResult ProductoGetBusqueda(ML.Producto producto) //datos para la búsqueda abierta
        {
            ML.Result result = new ML.Result();

            if (producto.SKU == null)
            {
                producto.SKU = "";
            }
            if (producto.Modelo == null)
            {
                producto.Modelo = "";
            }
            
            result = BL.Producto.ProductoGetBusqueda(producto);

            producto.Productos = result.Objects;

            return View(producto);
        }//GetAbierta
    }
}