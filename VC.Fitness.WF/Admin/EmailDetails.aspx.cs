using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.DAL;
using VelocityCoders.FitnessSchedule.Models.Collections;
using Jagtap.Common.Extensions;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin
{
    public partial class EmailDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindEmail();
        }

        #region Bind 
        private void BindEmail()
        {
            
            int emailId = Request.QueryString["EmailId"].ToInt();

            if (emailId > 0)
            {

                Email emailLookup = EmailDAL.GetItem(emailId);

                if (emailLookup != null)
                {
                    lblEmailId.Text = emailLookup.EmailId.ToString();
                    lblEntityTypeId.Text = emailLookup.EntityTypeId.ToString();
                    lblInstructorId.Text = emailLookup.InstructorId.ToString();
                    lblEmailAddress.Text = emailLookup.EmailAddress;
                }
                else
                    lblMessage.Text = "Email could not be found.";
            }
            else
                lblMessage.Text = "Invalid Id. Email record could not be found.";
        }
        #endregion
    }
}
