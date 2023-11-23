//using SysGymT.AccesoADatos;
//using SysGymT.EntidadesDeNegocio;
//using SysGymT.AccesoADatos;
//using SysGymT.EntidadesDeNegocio;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SysGymT.LogicaDeNegocio
//{
//    public class SaleBL
//    {
//        public async Task<int> CreateAsync(Sale sale)
//        {
//            return await SaleDAL.Create(sale);
//        }

//        public async Task<int> ModifyAsync(Sale sale)
//        {
//            return await SaleDAL.Modify(sale);
//        }

//        public async Task<int> DeleteAsync(Sale sale)
//        {
//            return await SaleDAL.Delete(sale);
//        }

//        public async Task<Sale> GetByIdAsync(Sale sale)
//        {
//            return await SaleDAL.GetById(sale);
//        }

//        public async Task<List<Sale>> GetAllAsync(Sale sale)
//        {
//            return await SaleDAL.GetAll();
//        }
//    }
//}