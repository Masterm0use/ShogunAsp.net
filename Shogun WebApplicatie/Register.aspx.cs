using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shogun_WebApplicatie
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
           
            //        if (txtPassword.Text == txtConfirmPassword.Text)
            //        {
            //            try
            //            {
            //                IdentityResult result = manager.Create(user, txtPassword.Text);
            //                if (result.Succeeded)
            //                {
            //                    UserDetail userDetail = new UserDetail
            //                    {
            //                        Address = txtAddress.Text,
            //                        FirstName = txtFirstName.Text,
            //                        LastName = txtLastName.Text,
            //                        Guid = user.Id,
            //                        PostalCode = Convert.ToInt32(txtPostalCode.Text)
            //                    };

                                  //TODO USER NAAR DATABASE WEGSCHRIJVEN
                                  //                     
            //                    //Als het gelukt is moet de gebruiker doorgaan naar de webpagina
            //                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
            //                    Response.Redirect("~/Index.aspx");
            //                }
            //                else
            //                {
            //                    litStatusMessage.Text = result.Errors.FirstOrDefault();
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                litStatusMessage.Text = ex.ToString();
            //            }
            //        }
            //        else
            //        {
            //            litStatusMessage.Text = "Passwords must match!";
            //        }
            //    }
            //}
        }
    }
}