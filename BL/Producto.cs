using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ML;
using System.Net.Http;


namespace BL
{
    public class Producto
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.OVillanuevaItalikaEntities context = new DL.OVillanuevaItalikaEntities())
                {

                    var ProductoGet = context.ProductoGet();

                    result.Objects = new List<object>();

                    if (ProductoGet != null)
                    {
                        foreach (var Obj in ProductoGet)
                        {

                            ML.Producto producto = new ML.Producto();

                            producto.SKU = Obj.SKU;
                            producto.Fert = Obj.Fert;
                            producto.Modelo = Obj.Modelo;
                            producto.Tipo = new ML.Tipo();
                            producto.Tipo.Nombre = Obj.Nombre;
                            producto.NumeroDeSerie = Obj.NumeroDeSerie;
                            producto.Fecha = Obj.Fecha.Value;

                            result.Objects.Add(producto);

                        }

                        result.Correct = true;

                    }
                    else
                    {

                        result.Correct = false;
                        result.ErrorMessage = "No existen coincidencias con los parámetros ingresados.";

                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }//GetAll

        public static ML.Result Add(ML.Producto producto)
        {

            ML.Result result = new ML.Result();

            try
            {

                using (DL.OVillanuevaItalikaEntities context = new DL.OVillanuevaItalikaEntities())
                {

                    var ProductoAdd = context.ProductoAdd(producto.SKU, producto.Fert, producto.Modelo, producto.Tipo.IdTipo, producto.NumeroDeSerie, DateTime.Now);

                    if (ProductoAdd >= 1)
                    {

                        result.Correct = true;

                    }//If
                    else
                    {

                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";

                    }//else

                    result.Correct = true;

                }//Using

                return result;

            }//Try

            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }//Add 

        public static ML.Result GetBySKU(string SKU)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.OVillanuevaItalikaEntities context = new DL.OVillanuevaItalikaEntities())
                {

                    var ProductoGetBySKU = context.ProductoGetBySKU(SKU).FirstOrDefault();

                    if (ProductoGetBySKU != null)
                    {

                        ML.Producto producto = new ML.Producto();

                        producto.SKU = SKU;
                        producto.Fert = ProductoGetBySKU.Fert;
                        producto.Modelo = ProductoGetBySKU.Modelo;
                        producto.Tipo = new ML.Tipo();
                        producto.Tipo.IdTipo = ProductoGetBySKU.IdTipo;
                        producto.Tipo.Nombre = ProductoGetBySKU.Nombre;
                        producto.NumeroDeSerie = ProductoGetBySKU.NumeroDeSerie;
                        producto.Fecha = ProductoGetBySKU.Fecha.Value;

                        result.Object = producto;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
            }
            return result;
        }//GetBySKU

        public static Result Update(ML.Producto producto)
        {

            Result result = new Result();

            try
            {

                using (DL.OVillanuevaItalikaEntities context = new DL.OVillanuevaItalikaEntities())
                {
                    var ProductoUpdate = context.ProductoUpdate(producto.SKU, producto.Fert, producto.Modelo, producto.Tipo.IdTipo, producto.NumeroDeSerie, DateTime.Now);

                    if (ProductoUpdate >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó!";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;


        }//Update

        public static Result Delete(string SKU)
        {

            Result result = new Result();

            try
            {
                using (DL.OVillanuevaItalikaEntities context = new DL.OVillanuevaItalikaEntities())
                {

                    var query = context.ProductoDelete(SKU);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }//Delete

        public static ML.Result ProductoGetBusqueda(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.OVillanuevaItalikaEntities context = new DL.OVillanuevaItalikaEntities())
                {

                    var query = context.ProductoGetBusqueda(producto.SKU, producto.Modelo).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var Obj in query)
                        {
                            ML.Producto item = new ML.Producto();

                            item.SKU = Obj.SKU;
                            item.Fert = Obj.Fert;
                            item.Modelo = Obj.Modelo;
                            item.Tipo = new ML.Tipo();
                            item.Tipo.Nombre = Obj.Nombre;
                            item.NumeroDeSerie = Obj.NumeroDeSerie;
                            item.Fecha = Obj.Fecha.Value;

                            result.Objects.Add(item);

                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
            }
            return result;
        }//BusquedaAbierta

        public static ML.Result GetAllByAPI()
        {
            ML.Result result = new ML.Result();

            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:30265/api/");

                    var responseTask = client.GetAsync("Producto/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        result.Objects = new List<object>();
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                            result.Objects.Add(resultItemList);
                        }

                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }//GetAllByApi

        public static ML.Result AddByAPI(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:30265/api/");

                    var postTask = client.PostAsJsonAsync<ML.Producto>("Producto/Add", producto);
                    postTask.Wait();

                    var resultAPI = postTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }//AddByApi

        public static ML.Result UpdateByApi(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:30265/api/");
                    var putTask = client.PutAsJsonAsync<ML.Producto>("Producto/Update", producto);
                    //var postTask = client.PostAsJsonAsync<ML.Producto>("Producto/Update", producto);
                    putTask.Wait();

                    var resultAPI = putTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;


        }//UpdateByApi

        public static ML.Result DeleteByAPI(string SKU)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:30265/api/");
                    //HTTP POST
                    var deleteTask = client.DeleteAsync("Producto/Delete/" + SKU);

                    deleteTask.Wait();

                    var resultAPI = deleteTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }//DeleteByApi


    }
}
