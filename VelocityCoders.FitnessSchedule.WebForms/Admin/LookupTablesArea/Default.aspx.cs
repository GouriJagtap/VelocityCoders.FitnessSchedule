using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace VelocityCoders.FitnessSchedule.WebForms.Admin.LookupTablesArea
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetMasterPageNavigation(Webforms.MasterNavigation.LookupTables);
        }
    }
}