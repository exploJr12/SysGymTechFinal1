//using SysGymT.EntidadesDeNegocio;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.PortableExecutable;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using SysGymT.EntidadesDeNegocio;

//namespace SysGymT.AccesoADatos
//{
//    public class SaleDAL
//    {
//        /* CREATE METHOD */
//        public static async Task<int> Create(Sale sale)
//        {
//            try
//            {
//                int result = 0;
//                using (var bdContext = new BDContexto())
//                {
//                    bdContext.Add(sale);
//                    result = await bdContext.SaveChangesAsync();
//                }
//                return result;

//            }
//            catch (Exception)
//            {
//                throw new Exception("Error Create method in SaleDAL");
//            }
//        }


//        /* MODIFY METHOD */
//        public static async Task<int> Modify(Sale sale)
//        {
//            try
//            {
//                int result = 0;
//                using (var bdContext = new BDContexto())
//                {
//                    var findSale = await bdContext.Sale.FirstOrDefaultAsync(s => s.IdSale == sale.IdSale);
//                    if (findSale != null)
//                    {
//                        findSale.Descriptions = sale.Descriptions;
//                        findSale.Amount = sale.Amount;
//                        findSale.TotalAmount = sale.TotalAmount;
//                        // ADD RELATIONS HERE

//                        bdContext.Update(findSale);
//                        result = await bdContext.SaveChangesAsync();
//                    }
//                    else
//                    {
//                        throw new Exception("La Venta no existe");
//                    }
//                }
//                return result;

//            }
//            catch (Exception)
//            {
//                throw new Exception("Error Modify method in SaleDAL");
//            }
//        }


//        /* DELETE METHOD */
//        public static async Task<int> Delete(Sale sale)
//        {
//            try
//            {
//                int result = 0;
//                using (var bdContext = new BDContexto())
//                {
//                    var findSale = await bdContext.Sale.FirstOrDefaultAsync(s => s.IdSale == sale.IdSale);
//                    if (findSale != null)
//                    {
//                        bdContext.Sale.Remove(findSale);
//                        result = await bdContext.SaveChangesAsync();
//                    }
//                }
//                return result;

//            }
//            catch (Exception)
//            {
//                throw new Exception("Error in Delete method in SaleDAL");
//            }
//        }


//        /* GET BY ID */

//        public static async Task<Sale> GetById(Sale sale)
//        {
//            try
//            {
//                var getSale = new Sale();
//                using (var bdContext = new BDContexto())
//                {
//                    getSale = await bdContext.Sale.FirstOrDefaultAsync(s => s.IdSale == sale.IdSale);
//                }
//                return getSale;

//            }
//            catch (Exception)
//            {
//                throw new Exception("Error in GetById method in SaleDAL");
//            }
//        }


//        /* GET ALL */

//        public static async Task<List<Sale>> GetAll()
//        {
//            try
//            {
//                var sales = new List<Sale>();
//                using (var bdContext = new BDContexto())
//                {
//                    sales = await bdContext.Sale.AsQueryable().ToListAsync();      //.Include(s => s.ola)
//                }
//                return sales;
//            }
//            catch (Exception)
//            {
//                throw new Exception("Error in GetAll method in SaleDAL");
//            }
//        }
//    }
//}