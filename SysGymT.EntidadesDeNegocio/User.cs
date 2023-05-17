﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SysGymT.EntidadesDeNegocio
{
    public class User
    {
        [Key]
        public int Id_User { get; set; }
        [ForeignKey("Rol")]
        [Required(ErrorMessage = "Rol es obligatorio")]
        [Display(Name = "Rol")]
        public int Id_Rol { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Apellido es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Login es obligatorio")]
        [StringLength(25, ErrorMessage = "Maximo 25 caracteres")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "Password debe estar entre 5 a 32 caracteres", MinimumLength = 5)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Estatus { get; set; }
        [Display(Name = "Fecha registro")]
        public DateTime Register_Date { get; set; }
        public Rol Rol { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Confirmar contraseña")]
        [StringLength(32, ErrorMessage = "Su contraseña debe estar entre 8 a 20 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Contraseña y confirmar contraseña deben de ser iguales")]
        [Display(Name = "Confirmar contraseña")]
        public string ConfirmPassword_Aux { get; set; }
    }
    public enum Estatus_User
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}