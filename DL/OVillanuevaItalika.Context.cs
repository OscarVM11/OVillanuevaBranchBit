﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OVillanuevaItalikaEntities : DbContext
    {
        public OVillanuevaItalikaEntities()
            : base("name=OVillanuevaItalikaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tipo> Tipoes { get; set; }
        public virtual DbSet<Producto> Productoes { get; set; }
    
        public virtual int ProductoAdd(string sKU, string fert, string modelo, Nullable<int> tipo, string numeroDeSerie, Nullable<System.DateTime> fecha)
        {
            var sKUParameter = sKU != null ?
                new ObjectParameter("SKU", sKU) :
                new ObjectParameter("SKU", typeof(string));
    
            var fertParameter = fert != null ?
                new ObjectParameter("Fert", fert) :
                new ObjectParameter("Fert", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(int));
    
            var numeroDeSerieParameter = numeroDeSerie != null ?
                new ObjectParameter("NumeroDeSerie", numeroDeSerie) :
                new ObjectParameter("NumeroDeSerie", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoAdd", sKUParameter, fertParameter, modeloParameter, tipoParameter, numeroDeSerieParameter, fechaParameter);
        }
    
        public virtual ObjectResult<ProductoGet_Result> ProductoGet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGet_Result>("ProductoGet");
        }
    
        public virtual ObjectResult<ProductoGetByModelo_Result> ProductoGetByModelo(string modelo)
        {
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetByModelo_Result>("ProductoGetByModelo", modeloParameter);
        }
    
        public virtual int ProductoUpdate(string sKU, string fert, string modelo, Nullable<int> tipo, string numeroDeSerie, Nullable<System.DateTime> fecha)
        {
            var sKUParameter = sKU != null ?
                new ObjectParameter("SKU", sKU) :
                new ObjectParameter("SKU", typeof(string));
    
            var fertParameter = fert != null ?
                new ObjectParameter("Fert", fert) :
                new ObjectParameter("Fert", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(int));
    
            var numeroDeSerieParameter = numeroDeSerie != null ?
                new ObjectParameter("NumeroDeSerie", numeroDeSerie) :
                new ObjectParameter("NumeroDeSerie", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoUpdate", sKUParameter, fertParameter, modeloParameter, tipoParameter, numeroDeSerieParameter, fechaParameter);
        }
    
        public virtual ObjectResult<TipoGet_Result> TipoGet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TipoGet_Result>("TipoGet");
        }
    
        public virtual int ProductoDelete(string sKU)
        {
            var sKUParameter = sKU != null ?
                new ObjectParameter("SKU", sKU) :
                new ObjectParameter("SKU", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoDelete", sKUParameter);
        }
    
        public virtual ObjectResult<GetByTipo_Result> GetByTipo(Nullable<int> idTipo)
        {
            var idTipoParameter = idTipo.HasValue ?
                new ObjectParameter("IdTipo", idTipo) :
                new ObjectParameter("IdTipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByTipo_Result>("GetByTipo", idTipoParameter);
        }
    
        public virtual ObjectResult<ProductoGetBySKU_Result> ProductoGetBySKU(string sKU)
        {
            var sKUParameter = sKU != null ?
                new ObjectParameter("SKU", sKU) :
                new ObjectParameter("SKU", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetBySKU_Result>("ProductoGetBySKU", sKUParameter);
        }
    
        public virtual ObjectResult<ProductoGetBusqueda_Result> ProductoGetBusqueda(string sKU, string modelo)
        {
            var sKUParameter = sKU != null ?
                new ObjectParameter("SKU", sKU) :
                new ObjectParameter("SKU", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetBusqueda_Result>("ProductoGetBusqueda", sKUParameter, modeloParameter);
        }
    }
}
