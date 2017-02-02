using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.BLL;
using VelocityCoders.FitnessSchedule.DAL;

    
    namespace VelocityCoders.FitnessSchedule.WebForms.Admin.GymLocationArea
{
    public partial class GymTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindGymList();
        }

        private void BindGymList()
        {
            int returnValue = 0;
            Gym gymtosave = new Gym();

            gymtosave.GymName = "tesdt";
            gymtosave.Abbreviation = "yyy";



            returnValue = GymManager.Save(gymtosave);

        }
    }
}