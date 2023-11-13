﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysGymT.EntidadesDeNegocio;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SysGymT.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Machines> Machines { get; set; }  
        public DbSet<Products> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Membership> Membership { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SysGymTech.mssql.somee.com;User ID=Explojr5_SQLLogin_1;Password=l6l6k8iqp2;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
