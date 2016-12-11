using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Webforms;
using VelocityCoders.FitnessSchedule.WebForms;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin.GymLocationArea
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetMasterPageNavigation(MasterNavigation.GymLocation);
        }
    }
}