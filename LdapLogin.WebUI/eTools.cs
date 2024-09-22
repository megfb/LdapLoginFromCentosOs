using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;


namespace LdapLogin.WebUI
{
    public class eTools
    {
        //const string LDAP_PATH = "Ldap://mehmet.com";
        //const string LDAP_DOMAIN = "10.3.0.2";
        //public Task<AuthenticateResult> HandleAuthenticateAsync(string id, string pass)
        //{
        //    using (var context = new PrincipalContext(ContextType.Domain, LDAP_DOMAIN, "Administrator", "Me733017"))
        //    {
        //        if (context.ValidateCredentials(id, pass))
        //        {
        //            using (var de = new DirectoryEntry(LDAP_PATH))
        //            using (var ds = new DirectorySearcher(de))
        //            {
        //                var identities = new List<ClaimsIdentity> { new ClaimsIdentity("custom auth type") };
        //                var ticket = new AuthenticationTicket(new ClaimsPrincipal(identities), Options.DefaultName);
        //                return Task.FromResult(AuthenticateResult.Success(ticket));
        //            }
        //        }
        //        else
        //        {
        //            return Task.FromResult(AuthenticateResult.Fail("Invalid auth key."));
        //        }
        //    }
        //}


        public string RunCommand()
        {
            string command = "/root/Desktop/asd/script.pl";
            string result = "";
            using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
            {
                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c \" " + command + " \"";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.Start();

                result += proc.StandardOutput.ReadToEnd();
                result += proc.StandardError.ReadToEnd();

                proc.WaitForExit();
            }
            return result;
        }
       
        public string oku()
        {
            string serial = File.ReadAllText(@"/root/Desktop/asd/scr.out");
            return serial;
        }
        

        public void logla(string log)
        {
            
            if (File.Exists(@"/root/Desktop/asd/logs.txt") == false)
            {
                File.Create(@"/root/Desktop/asd/logs.txt");
                File.WriteAllText(@"/root/Desktop/asd/logs.txt", log);
            }
            else
            {
                File.AppendAllText(@"/root/Desktop/asd/logs.txt", log);
            }
        }


       
    }
}


