using System;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OWASP.WebGoat.NET.App_Code.DB;
using OWASP.WebGoat.NET.App_Code;
using log4net;
using System.Reflection;

namespace OWASP.WebGoat.NET.WebGoatCoins
{
    public partial class CustomerLogin : System.Web.UI.Page
    {
        private IDbProvider du = Settings.CurrentDbProvider;
        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelError.Visible = false;

            string returnUrl = Request.QueryString["ReturnUrl"];
            if (returnUrl != null)
            {
                PanelError.Visible = true;
            }
        }

        private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]{1,64}@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        protected void ButtonLogOn_Click(object sender, EventArgs e)
        {
            string email = txtUserName.Text.Trim();
            string pwd = txtPassword.Text;

            // Validate email format before processing
            if (!EmailRegex.IsMatch(email))
            {
                labelError.Text = "Please enter a valid email address.";
                PanelError.Visible = true;
                return;
            }

            // Sanitize email for logging to prevent log injection
            string safeEmail = email.Replace("\r", "").Replace("\n", "");
            log.Info("User " + safeEmail + " attempted to log in.");

            if (!du.IsValidCustomerLogin(email, pwd))
            {
                labelError.Text = "Incorrect username/password"; 
                PanelError.Visible = true;
                return;
            }
            // put ticket into the cookie
            FormsAuthenticationTicket ticket =
                        new FormsAuthenticationTicket(
                            1, //version 
                            email, //name 
                            DateTime.Now, //issueDate
                            DateTime.Now.AddDays(14), //expireDate 
                            true, //isPersistent
                            "customer", //userData (customer role)
                            FormsAuthentication.FormsCookiePath //cookiePath
            );

            string encrypted_ticket = FormsAuthentication.Encrypt(ticket); //encrypt the ticket

            // put ticket into the cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted_ticket);

            //set expiration date
            if (ticket.IsPersistent)
                cookie.Expires = ticket.Expiration;
                
            Response.Cookies.Add(cookie);
            
            string returnUrl = Request.QueryString["ReturnUrl"];
            
            if (returnUrl == null) 
                returnUrl = "/WebGoatCoins/MainPage.aspx";
                
            Response.Redirect(returnUrl);        
        }
    }
}