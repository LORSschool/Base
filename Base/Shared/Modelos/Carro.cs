using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Modelos
{
    public class Carro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "debe escribir el nombre")]
        [StringLength(10)]
        public string? Nombredelcarro { get; set; }
        [Required(ErrorMessage = "debe escribir la marca")]
        [StringLength(100)]
        public string? Marcadelcarro { get; set; }
        [Required(ErrorMessage = "debe escribir la año de creacion")]
        public int Año { get; set; }

        public int CiudadId { get; set; }
        public Ciudad? Ciudad { get; set; }

        public int CondicionId { get; set; }    
        public Condicion? Condicion { get; set;}
    }
}
