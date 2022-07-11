using AppFinanciera.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AppFinanciera.Servicios
{
    /// <summary>
    /// Descripción breve de UsuariosExtra
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class UsuariosExtra : System.Web.Services.WebService
    {

        private ModelFinancieraContainer db = new ModelFinancieraContainer();

        //Login
        [WebMethod]
        public bool Login(string email, string pass)
        {
            var result =
            HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>().PasswordSignIn(email, pass,
            false, false);
            if (result == SignInStatus.Success)
            {
                return true;
            }
            else return false;
        }

        //[WebMethod]
        //public bool AddUser(string Email, string Pass)
        //{
        //    bool band = false;
        //    ApplicationDbContext context = new ApplicationDbContext();
        //    var UserManager = new UserManager<ApplicationUser>(new
        //    UserStore<ApplicationUser>(context));
        //    //Here we create a Admin super user who will maintain the website
        //    var user = new ApplicationUser();
        //    user.Email = Email;
        //    user.P = Pass;
        //    string userPWD = Pass;
        //    var chkUser = UserManager.Create(Email, Pass);
        //    //Add default User to Role Admin
        //    if (chkUser.Succeeded)
        //    {
        //        var result1 = UserManager.AddToRole(user.Id, "freemium");
        //        band = true;
        //    }
        //    else band = false;
        //    //Agregamos una persona
        //    return band;
        //}

       // GET: UsuarioExtraInfoes
       //[WebMethod]
       // public List<Models.DTO.UsuarioExtraInfo> GetInfo()
       // {
       //     return (db.Usuarios.Where(u => u.EsActivo)
       //         .Select(u => new Models.DTO.UsuarioExtraInfo
       //         {
       //             Apellido = u.Apellido,
       //             Apodo = u.Apodo
       //         }).ToList());

       // }

       // GET: UsuarioExtraInfoes/Details/5
       // [WebMethod]
       // public Models.DTO.UsuarioExtraInfo Details(int? id)
       // {
       //     if (id == null)
       //     {
       //         return null;
       //     }
       //     UsuarioExtraInfo u = db.Usuarios.Find(id);
       //     if (u == null)
       //     {
       //         return null;
       //     }
       //     return new Models.DTO.UsuarioExtraInfo
       //     {
       //         Apellido = u.Apellido,
       //         Apodo = u.Apodo
       //     };
       // }

       // [WebMethod]
       // public bool CrearUsuario(UsuarioExtraInfo usuarioExtraInfo)
       // {
       //     db.Usuarios.Add(usuarioExtraInfo);
       //     db.SaveChanges();

       //     return true;
       // }

       // GET: UsuarioExtraInfoes/Edit/5
       // [WebMethod]

       // public bool ModificarUsuario(UsuarioExtraInfo usuarioExtraInfo)
       // {
       //     db.Entry(usuarioExtraInfo).State = EntityState.Modified;
       //     db.SaveChanges();

       //     return true;
       // }

       // [WebMethod]
       // public bool EliminarUsuario(int id)
       // {
       //     UsuarioExtraInfo usuarioExtraInfo = db.Usuarios.Find(id);
       //     usuarioExtraInfo.EsActivo = false;
       //     db.Entry(usuarioExtraInfo).State = EntityState.Modified;
       //     db.SaveChanges();
       //     return true;
       // }

    }
}

