//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel;
//using System.Globalization;

//namespace SysGymT.EntidadesDeNegocio
//{
//    public class Sale
//    {
//        [Key]
//        public int IdSale { get; set; }
//        [DisplayName("Usuario")]
//        public int Id_Usuario { get; set; }
    
//        [DisplayName("Cliente")]
//        public int Id_Customer { get; set; }
//        [Required]
//        [DisplayName("Detalles de venta")]
//        public string IdDetails { get; set; }
//        [Required]
//        [DisplayName("Monto a pagar")]
//        public decimal AmountPage { get; set; }
//        [Required]
//        [DisplayName("Monto de cambio")]
//        public decimal AmountChanges { get; set; }
//        [Required]
//        [DisplayName("Monto total")]
//        public decimal TotalAmount { get; set; }
//        public List<Details> Details { get; set; }
//        public List<Customer> Customers { get; set; }
//        [NotMapped]
//        public int Top_Aux { get; set; }
//    }
//}