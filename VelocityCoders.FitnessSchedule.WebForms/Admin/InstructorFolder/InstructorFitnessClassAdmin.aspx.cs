using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Webforms;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin.InstructorFolder
{
    public partial class InstructorFitnessClassAdmin : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetInstructorId();
            this.BindInstructorNavigation();
            base.SetMasterPageNavigation(MasterNavigation.Instructor);
        }

        #region BIND CONTROLS

        private void BindInstructorNavigation()
        {
            instructorNavigation.CurrentNavigationLink = InstructorNavigation.ContactInfo;

            instructorNavigation.InstructorId = base.InstructorId;
        }

        private void SetInstructorId()
        {
            litInstructorId.Text = "<input type='hidden' id=InstructorId' value='" + base.InstructorId.ToString() + "'/>";
        }
        #endregion
    }
}