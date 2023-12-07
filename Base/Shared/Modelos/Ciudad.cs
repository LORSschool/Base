using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Modelos
{
    public class Ciudad
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "debe escribir el nombre del salon ")]
        [StringLength(10)]
        public string? Nombredeciudad { get; set; }
        
        public virtual ICollection<Carro>? Carros { get; set; }    
    }
}
