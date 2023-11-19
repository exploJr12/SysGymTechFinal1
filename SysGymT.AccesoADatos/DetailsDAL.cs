﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SysGymT.EntidadesDeNegocio;

namespace SysGymT.AccesoADatos
{
    public class DetailsDAL
    {

        /* CREATE METHOD */
        public static async Task<int> Create(Details details)
        {
            try
            {
                int result = 0;
                using (var bdContext = new BDContexto())
                {
                    bdContext.Add(details);
                    result = await bdContext.SaveChangesAsync();
                }
                return result;

            } catch (Exception)
            {
                throw new Exception("Error in create method DetailsDAL");
            }
        }


        /* MODIFY METHOD */
        public static async Task<int> Modify(Details details)
        {
            try
            {
                int result = 0;
                using (var bdContext = new BDContexto())
                {
                    var findDetails = await bdContext.Details.FirstOrDefaultAsync(d => d.IdDetails == details.IdDetails);
                    if (findDetails != null)
                    {
                        findDetails.Quantity = details.Quantity;
                        findDetails.DateSale = details.DateSale;
                        // ADD RELATIONS HERE
                    }
                    else
                    {
                        throw new Exception("El detalle no existe");
                    }
                }
                return result;
            } catch (Exception)
            {
                throw new Exception("Error in modify method DetailsDAL");
            }
        }


        /* DELETE METHOD */

        public static async Task<int> Delete(Details details)
        {
            try
            {
                int result = 0;
                using (var bdContext = new BDContexto())
                {
                    var findDetails = await bdContext.Details.FirstOrDefaultAsync(d => d.IdDetails == details.IdDetails);
                    if (findDetails != null)
                    {
                        bdContext.Details.Remove(findDetails);
                        result = await bdContext.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Detalles no existe");
                    }
                }
                return result;
            } catch (Exception)
            {
                throw new Exception("Error in Delete method DetailsDAL");
            }
        }

        /* GET BY ID */

        public static async Task<Details> GetById(Details details)
        {
            try
            {
                var getDetails = new Details();
                using (var bdContext = new BDContexto())
                {
                    getDetails = await bdContext.Details.FirstOrDefaultAsync(d => d.IdDetails == details.IdDetails);
                }
                return getDetails;
            } catch (Exception)
            {
                throw new Exception("Error in GetById method of DetailsDAL");
            }
        }

        public static async Task<List<Details>> GetAll()
        {
            try
            {
                var details = new List<Details>();
                using (var bdContext = new BDContexto())
                {
                    details = await bdContext.Details.AsQueryable().ToListAsync();      //.Include(s => s.ola)
                }
                return details;
            } catch (Exception)
            {
                throw new Exception("Error in GetAll method in DetailsDAL");
            }
        }
    }
}