using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jagtap.Common.Extensions;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.DAL;


namespace VelocityCoders.FitnessSchedule.WebForms.Admin
{
    public partial class PersonDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindPerson();
        }

        #region Bind 

        private void BindPerson()
        {
            int personId = Request.QueryString["PersonId"].ToInt();

            if (personId > 0)
            {
                Person personLookup = PersonDAL.GetItem(personId);

                if (personLookup != null)
                {
                    lblPersonId.Text = personLookup.PersonId.ToString();
                    lblFirstName.Text = personLookup.FirstName;
                    lblLastName.Text = personLookup.LastName;
                    lblDisplayFirstName.Text = personLookup.DisplayFirstName;
                    lblGender.Text = personLookup.Gender;
                }
                else
                    lblMessage.Text = "Person could not be found.";
            }
            else
                lblMessage.Text = "Invalid Id. Person record could not be found.";
        }
        #endregion
    }
}