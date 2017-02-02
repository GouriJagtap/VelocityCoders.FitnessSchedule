using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Models.Collections;
using VelocityCoders.FitnessSchedule.DAL;
using VelocityCoders.FitnessSchedule.Models;
using Jagtap.Common.Extensions;


namespace VelocityCoders.FitnessSchedule.WebForms.Admin
{
    public partial class FitnessClassList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindFitnessClass();
        }
        private void BindFitnessClass()
        {
            FitnessClassCollection fitnessList = new FitnessClassCollection();
            fitnessList = FitnessClassDAL.GetCollection();
            rptFitnessClassList.DataSource = fitnessList;
            rptFitnessClassList.DataBind();

        }
    }
}