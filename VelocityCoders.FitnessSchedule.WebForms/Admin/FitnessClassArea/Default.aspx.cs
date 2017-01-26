using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Webforms;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin.FitnessClassArea
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetMasterPageNavigation(MasterNavigation.FitnessClass);

        }
    }
}