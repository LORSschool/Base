using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Modelos
{
    public class Condicion
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "debe escribir el estado del carro")]
        [StringLength(10)]
        public string? Estadodelcarro { get; set; }

        public virtual ICollection<Carro>? Carros { get; set; } 
    }
}
