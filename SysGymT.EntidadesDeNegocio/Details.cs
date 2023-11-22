using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SysGymT.EntidadesDeNegocio
{
    public class Details
    {
        [Key]
        public int IdDetails { get; set; }

        [Required]
        [DisplayName("Productos")]
        public int Id_products { get; set; }


        [Required]
        [DisplayName("Cantidad")]
        public int Quantity { get; set; }


        [Required]
        [DisplayName("Fecha de venta")]
        public string DateSale { get; set; }
    }
}