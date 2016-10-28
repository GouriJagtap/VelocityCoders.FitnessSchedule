using Jagtap.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.DAL;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin
{
    public partial class InstructorDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindInstructor();
        }
        #region Bind 

        private void BindInstructor()
        {
            int instructorId = Request.QueryString["InstructorId"].ToInt();

            if (instructorId > 0)
            {
                
                Instructor instructorLookup = InstructorDAL.GetItem(instructorId);

                if (instructorLookup != null)
                {
                  
                     lblInstructorId.Text = instructorLookup.InstructorId.ToString();
                    lblPersonId.Text = instructorLookup.PersonId.ToString();
                    lblHireDate.Text = instructorLookup.HireDate.ToShortDateString();
                    lblTermDate.Text = instructorLookup.TermDate.ToShortDateString();
                    lblCreateDate.Text = instructorLookup.CreateDate.ToShortDateString();
                }
                else
                    lblMessage.Text = "Instructor could not be found.";
            }
            else
                lblMessage.Text = "Invalid Id. Instructor record could not be found.";
        }
        #endregion
    }
}