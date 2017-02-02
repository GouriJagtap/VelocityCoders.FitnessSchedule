using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Webforms;

namespace VelocityCoders.FitnessSchedule.WebForms.MasterPages
{
    public partial class Site2Column : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindMasterNavigation();
        }
        #region PROPERTIES

        public MasterNavigation SelectedMasterPageNavigation { get; set; }

        #endregion

        #region BIND CONTROLS

        private void BindMasterNavigation()
        {
            switch(this.SelectedMasterPageNavigation)
            {
                case MasterNavigation.Instructor:
                    Instructor.Attributes.Add("class", "Selected");
                    break;

                case MasterNavigation.GymLocation:
                    GymLocation.Attributes.Add("class", "Selected");
                    break;

                case MasterNavigation.FitnessClass:
                    FitnessClass.Attributes.Add("class", "Selected");
                    break;

                case MasterNavigation.Schedule:
                    Schedule.Attributes.Add("class", "Selected");
                    break;

                case MasterNavigation.LookupTables:
                    LookupTables.Attributes.Add("class", "Selected");
                    break;
            }
        }
        #endregion
    }
}