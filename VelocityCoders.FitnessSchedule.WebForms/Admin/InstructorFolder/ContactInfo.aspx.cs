using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin.InstructorFolder
{
    public partial class ContactInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindInstructorNavigation();
        }
        #region BIND CONTROLS
        private void BindInstructorNavigation()
        {
            instructorNavigation.CurrentNavigationLink = InstructorNavigation.ContactInfo;

            instructorNavigation.InstructorId = 1;
        }
        #endregion

    }
}