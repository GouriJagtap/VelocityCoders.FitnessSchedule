using Jagtap.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.DAL;
using VelocityCoders.FitnessSchedule.Models;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin
{
    public partial class FitnessCLassDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindFitnessClass();
        }
        #region Bind 

        private void BindFitnessClass()
        {
            int fitnessClassId = Request.QueryString["FitnessClassId"].ToInt();

            if (fitnessClassId > 0)
            {

                FitnessClass fitnessClassLookup = FitnessClassDAL.GetItem(fitnessClassId);

                if (fitnessClassLookup != null)
                {
                    lblFitnessClassId.Text = fitnessClassLookup.FitnessClassId.ToString();
                    lblFitnessClassName.Text = fitnessClassLookup.FitnessClassName;
                    
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