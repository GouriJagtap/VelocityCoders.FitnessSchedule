using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin.InstructorFolder
{
    public partial class InstructorForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPageMessage.Text = DateTime.Now.ToLongTimeString();
            txtFirstName.Text = "Default Value";
        }
        private void ProcessForm()
        {
            StringBuilder formValues = new StringBuilder();

            string firstName = txtFirstName.Text;
            string preferedFirstName = txtPreferedFirstName.Text;
            string lastName = txtLastName.Text;
            string birthDate = txtBirthDate.Text;
            string hireDate = txtHireDate.Text;
            string termDate = txtTermDate.Text;
            string employeeType = drpEmployeeType.SelectedItem.Text;
            string gender = drpGender.SelectedItem.Text;
            string notes = txtNotes.Text;

            formValues.Append("First Name :" + firstName);
            formValues.Append("<br />");
            formValues.Append("Preferred First Name :" + preferedFirstName);
            formValues.Append("<br />");
            formValues.Append("Last Name :" + lastName);
            formValues.Append("<br />");
            formValues.Append("Birth Date :" + birthDate);
            formValues.Append("<br />");
            formValues.Append("Hire Date :" + hireDate);
            formValues.Append("<br />");
            formValues.Append("Termination Date :" + termDate);
            formValues.Append("<br />");
            formValues.Append("Employee Type :" + employeeType);
            formValues.Append("<br />");
            formValues.Append("Gender :" + gender);
            formValues.Append("<br />");
            formValues.Append("Notes :" + notes);
            formValues.Append("<br />");


        }
    }
}