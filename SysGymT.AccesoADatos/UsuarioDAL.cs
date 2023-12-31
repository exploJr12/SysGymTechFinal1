﻿using Microsoft.EntityFrameworkCore;
using SysGymT.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SysGymT.AccesoADatos
{
    public class UsuarioDAL
    {
        private static void EncriptarMD5(Usuario pUsuario)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(pUsuario.Password));
                var strEncriptar = "";
                for (int i = 0; i < result.Length; i++)
                    strEncriptar += result[i].ToString("x2").ToLower();
                pUsuario.Password = strEncriptar;
            }
        }
        private static async Task<bool> ExisteLogin(Usuario pUsuario, BDContexto pDbContext)
        {
            bool result = false;
            var loginUsuarioExiste = await pDbContext.Usuario.FirstOrDefaultAsync(s => s.Login == pUsuario.Login && s.Id_Usuario != pUsuario.Id_Usuario);
            if (loginUsuarioExiste != null && loginUsuarioExiste.Id_Usuario > 0 && loginUsuarioExiste.Login == pUsuario.Login)
                result = true;
            return result;
        }
        #region CRUD
        public static async Task<int> CrearAsync(Usuario pUsuario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bool existeLogin = await ExisteLogin(pUsuario, bdContexto);
                if (existeLogin == false)
                {
                    pUsuario.FechaRegistro = DateTime.Now;
                    EncriptarMD5(pUsuario);
                    bdContexto.Add(pUsuario);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("Login ya existe");
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Usuario pUsuario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bool existeLogin = await ExisteLogin(pUsuario, bdContexto);
                if (existeLogin == false)
                {
                    var usuario = await bdContexto.Usuario.FirstOrDefaultAsync(s => s.Id_Usuario == pUsuario.Id_Usuario);
                    //error de revisar por editar y supongamos que eliminar tambien
                    usuario.Id_Rol = pUsuario.Id_Rol;
                    usuario.Nombre_Completo = pUsuario.Nombre_Completo;
                    usuario.Login = pUsuario.Login;
                    usuario.Estatus = pUsuario.Estatus;
                    bdContexto.Update(usuario);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("Login ya existe");
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Usuario pUsuario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var usuario = await bdContexto.Usuario.FirstOrDefaultAsync(s => s.Id_Usuario == pUsuario.Id_Usuario);
                bdContexto.Usuario.Remove(usuario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Usuario> ObtenerPorIdAsync(Usuario pUsuario)
        {
            var usuario = new Usuario();
            using (var bdContexto = new BDContexto())
            {
                usuario = await bdContexto.Usuario.FirstOrDefaultAsync(s => s.Id_Usuario == pUsuario.Id_Usuario);
            }
            return usuario;
        }
        public static async Task<List<Usuario>> ObtenerTodosAsync()
        {
            var usuarios = new List<Usuario>();
            using (var bdContexto = new BDContexto())
            {
                usuarios = await bdContexto.Usuario.ToListAsync();
            }
            return usuarios;
        }
        internal static IQueryable<Usuario> QuerySelect(IQueryable<Usuario> pQuery, Usuario pUsuario)
        {
            if (pUsuario.Id_Usuario > 0)
                pQuery = pQuery.Where(s => s.Id_Usuario == pUsuario.Id_Usuario);
            if (pUsuario.Id_Rol > 0)
                pQuery = pQuery.Where(s => s.Id_Rol == pUsuario.Id_Rol);
            if (!string.IsNullOrWhiteSpace(pUsuario.Nombre_Completo))
                pQuery = pQuery.Where(s => s.Nombre_Completo.Contains(pUsuario.Nombre_Completo));
            if (!string.IsNullOrWhiteSpace(pUsuario.Login))
                pQuery = pQuery.Where(s => s.Login.Contains(pUsuario.Login));
            if (pUsuario.Estatus > 0)
                pQuery = pQuery.Where(s => s.Estatus == pUsuario.Estatus);
            if (pUsuario.FechaRegistro.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pUsuario.FechaRegistro.Year, pUsuario.FechaRegistro.Month, pUsuario.FechaRegistro.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaRegistro >= fechaInicial && s.FechaRegistro <= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.Id_Usuario).AsQueryable();
            if (pUsuario.Top_Aux > 0)
                pQuery = pQuery.Take(pUsuario.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Usuario>> BuscarAsync(Usuario pUsuario)
        {
            var Usuarios = new List<Usuario>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Usuario.AsQueryable();
                select = QuerySelect(select, pUsuario);
                Usuarios = await select.ToListAsync();
            }
            return Usuarios;
        }
        #endregion
        public static async Task<List<Usuario>> SearchIncludeUsuarioAsync(Usuario pUsuario)
        {
            var usuarios = new List<Usuario>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Usuario.AsQueryable();
                select = QuerySelect(select, pUsuario).Include(s => s.Rol).AsQueryable();
                usuarios = await select.ToListAsync();
            }
            return usuarios;
        }
        public static async Task<Usuario> LoginAsync(Usuario pUsuario)
        {
            var usuario = new Usuario();
            using (var bdContexto = new BDContexto())
            {
                EncriptarMD5(pUsuario);
                usuario = await bdContexto.Usuario.FirstOrDefaultAsync(s => s.Login == pUsuario.Login &&
                s.Password == pUsuario.Password && s.Estatus == (byte)Estatus_Usuario.ACTIVO);
            }
            return usuario;
        }
        public static async Task<int> CambiarPasswordAsync(Usuario pUsuario, string pPasswordAnt)
        {
            int result = 0;
            var usuarioPassAnt = new Usuario { Password = pPasswordAnt };
            EncriptarMD5(usuarioPassAnt);
            using (var bdContexto = new BDContexto())
            {
                var usuario = await bdContexto.Usuario.FirstOrDefaultAsync(s => s.Id_Usuario == pUsuario.Id_Usuario);
                if (usuarioPassAnt.Password == usuario.Password)
                {
                    EncriptarMD5(pUsuario);
                    usuario.Password = pUsuario.Password;
                    bdContexto.Update(usuario);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("El password actual es incorrecto");
            }
            return result;
        }
    }
}
