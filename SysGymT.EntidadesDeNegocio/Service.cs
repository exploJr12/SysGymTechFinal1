using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SysGymT.EntidadesDeNegocio
{
    public class Service
    {
        [Key]
        public int Id_Service { get; set; }


        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        [DisplayName("Nombre del servicio")]
        public string Name_Service { get; set; }


        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        [DisplayName("Descripcion")]
        public string Descryption { get; set; }


        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
