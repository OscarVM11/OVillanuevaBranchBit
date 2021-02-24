using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Tipo
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.OVillanuevaItalikaEntities context = new DL.OVillanuevaItalikaEntities())
                {

                    var TipoGet = context.TipoGet();

                    result.Objects = new List<object>();

                    if (TipoGet != null)
                    {
                        foreach (var Obj in TipoGet)
                        {

                            ML.Tipo tipo = new ML.Tipo();

                            tipo.IdTipo = Obj.IdTipo;
                            tipo.Nombre = Obj.Nombre;

                            result.Objects.Add(tipo);

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
        }//GEtAll

        public static ML.Result GetByTipo(int IdTipo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.OVillanuevaItalikaEntities context = new DL.OVillanuevaItalikaEntities())
                {

                    var TipoGet = context.GetByTipo(IdTipo).FirstOrDefault();

                    if (TipoGet != null)
                    {

                        ML.Tipo tipo = new ML.Tipo();

                        tipo.IdTipo = IdTipo;
                        tipo.Nombre = TipoGet.Nombre;
                        
                        result.Object = tipo;

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
    }
}
