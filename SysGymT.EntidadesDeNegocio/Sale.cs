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
    public class Sale
    {
        [Key]
        public int IdSale { get; set; }



        [DisplayName("Usuario")]
        public int Id_Usuario { get; set; }



        [DisplayName("Cliente")]
        public int Id_Customer { get; set; }


        [Required]
        [DisplayName("Detalles de venta")]
        public string IdDetails { get; set; }


        [Required]
        [DisplayName("Descripcion")]
        public string Descriptions { get; set; }


        [Required]
        [DisplayName("Monto")]
        public int Amount { get; set; }


        [Required]
        [DisplayName("Monto total")]
        public int TotalAmount { get; set; }

    }
}