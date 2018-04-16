using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cibertec.Mvc.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Display(Name = "Fecha de Estreno")]
        public DateTime FechaEstreno { get; set; }
        [Display(Name = "Género")]
        public string Genero { get; set; }
        [Display(Name = "Precio (S/)")]
        public decimal Precio { get; set; }
    }

    public class PeliculaDbContext : DbContext
    {
        public DbSet<Pelicula> Peliculas { get; set; }        
    }
}