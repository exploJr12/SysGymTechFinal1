using SysGymT.AccesoADatos;
using SysGymT.EntidadesDeNegocio;
using SysGymT.AccesoADatos;
using SysGymT.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGymT.LogicaDeNegocio
{
    public class DetailsBL
    {
        public async Task<int> CreateAsync(Details details)
        {
            return await DetailsDAL.Create(details);
        }

        public async Task<int> ModifyAsync(Details details)
        {
            return await DetailsDAL.Modify(details);
        }

        public async Task<int> DeleteAsync(Details details)
        {
            return await DetailsDAL.Delete(details);
        }

        public async Task<Details> getByIdAsync(Details details)
        {
            return await DetailsDAL.GetById(details);
        }

        public async Task<List<Details>> GetAllDetails(Details details)
        {
            return await DetailsDAL.GetAll();
        }
    }
}