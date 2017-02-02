using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.DAL;
using VelocityCoders.FitnessSchedule.Models.Collections;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin.GymLocationArea
{
    public partial class GymList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindGymList();
        }
        private void BindGymList()
        {
            GymCollection gymList = new GymCollection();

            gymList = GymDAL.GetCollection();

            //Bind to Repeater
            rptEmailList.DataSource = gymList;
            rptEmailList.DataBind();
        }
    }

}