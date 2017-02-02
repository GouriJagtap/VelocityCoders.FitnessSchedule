using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Webforms;


namespace VelocityCoders.FitnessSchedule.WebForms.Admin.LookupTablesArea
{
    public partial class EntityLookup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindNavigation();
            }
           
        }

        #region BIND CONTROLS

        private void BindNavigation()
        {
            lookupTablesNavigation.CurrentNavigationLink = LookupTablesNavigation.EntityType;
        }
        #endregion
    }
}