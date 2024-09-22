using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Novell.Directory.Ldap;

namespace LdapLogin.WebUI.Controllers
{
    public class LdapConController : Controller
    {
        eTools etl = new eTools();
        public IActionResult Home()
        {
            return View();
        }
        public static string _id;
        public static string person;


        [HttpPost]
        public IActionResult Home(string id, string pass)
        {
            string userDn = $"{id}@ghtr.local";

            using (LdapConnection connection = new LdapConnection { SecureSocketLayer = false })
            {
                connection.Connect("10.3.0.2", LdapConnection.DEFAULT_PORT);
                connection.Bind(userDn, pass);
                if (connection.Bound)
                {
                    _id = id;
                    person = id;
                    return Redirect("/LdapCon/KeyReq");
                }
                else
                {
                    ViewBag.mesaj = "Hatalı Giriş";
                    return View();
                }
            }
        }

        public IActionResult KeyReq()
        {
            if (_id != null)
            {
                ViewBag.mesaj = $"Hoşgeldiniz {_id}";
                _id = null;
                return View();
            }
            else
            {
                return Redirect("/LdapCon/Home");
            }
        }

        [HttpPost]
        public IActionResult KeyReq(string aciklama)
        {
            if (aciklama != null)
            {
                etl.RunCommand();
                string log = $"{DateTime.Now.ToString()} - {person} - {aciklama} - {etl.oku()} &&&&";
                etl.logla(log);
                ViewBag.mesaj = $"İşlem Başarılı. log bilginiz:{log}";
                _id = null;
                return View();
            }
            else
            {
                ViewBag.mesaj = "Lütfen Açıklama Giriniz";
                return View();
            }
        }


    }
}
