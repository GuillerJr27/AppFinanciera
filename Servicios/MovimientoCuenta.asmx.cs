using AppFinanciera.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AppFinanciera.Servicios
{
    /// <summary>
    /// Descripción breve de MovimientoCuenta
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class MovimientoCuenta : System.Web.Services.WebService
    {
        private ModelFinancieraContainer db = new ModelFinancieraContainer();

        [WebMethod]
        public List<Models.DTO.CuentaUsuario> GetCuentaUSuario(int userID = 0)
        {
            var info = userID != 0 ? db.CuentaUsuarios.Where(u => u.UsuarioExtraInfoId == userID).ToList() : db.CuentaUsuarios.ToList();
            return info.Select(c => new Models.DTO.CuentaUsuario { Id = c.Id }).ToList();

        }

        // GET: UsuarioExtraInfoes/Details/5
        [WebMethod]
        public Models.DTO.CuentaUsuario DetalleCuenta(int? id)
        {
            if (id == null)
            {
                return null;
            }
            CuentaUsuario detalle = db.CuentaUsuarios.Find(id);
            if (detalle == null)
            {
                return null;
            }
            return new Models.DTO.CuentaUsuario { Id = detalle.Id };
        }

        [WebMethod]
        public bool CuentaUsuario(Models.DTO.CuentaUsuario cta)
        {
            var u = new CuentaUsuario { NombreCuenta  = cta.NombreCuenta };
            db.CuentaUsuarios.Add(u);
            db.SaveChanges();

            return true;
        }

        [WebMethod]
        public bool ModificarCuentaUsuario(Models.DTO.CuentaUsuario cta)
        {
            var u = new CuentaUsuario { Id = cta.Id, NombreCuenta = cta.NombreCuenta };
            db.Entry(u).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }

        [WebMethod]
        public bool EliminarCuentaUsuario(int id)
        {
            CuentaUsuario cuentaUsuario = db.CuentaUsuarios.Find(id);
            db.Entry(cuentaUsuario).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}
