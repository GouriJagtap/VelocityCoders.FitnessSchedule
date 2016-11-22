using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Manager;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;
using Jagtap.Common.Extensions;
using Jagtap.Common;
using VelocityCoders.FitnessSchedule.BLL;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin.InstructorFolder
{
    public partial class InstructorForm : BasePage
    {

        #region EVENT HANDLERS
        protected void Page_Load(object sender, EventArgs e)
        {
            // lblPageMessage.Text = InstructorNavigation.InstructorForm.ToString();
            //instructorNavigation.CurrentNavigationLink = InstructorNavigation.InstructorForm;

           
            if (Page.IsPostBack)
            {
                    this.BindInstructorNavigation();

             }
             else
            {

                this.BindInstructorNavigation();
                this.BindEmployeeType();
                this.CheckUpdate();
                
            }
          

        }
       
        protected void Save_Click(object sender, EventArgs e)
        
        {
          this.ProcessForm();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorForm.aspx");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            this.DeleteInstructor();
        }

        #endregion EVENT HANDLERS

        private void ProcessForm()
        {
            StringBuilder formValues = new StringBuilder();

            string firstName = txtFirstName.Text;
            string preferedFirstName = txtPreferedFirstName.Text;
            string lastName = txtLastName.Text;
            string birthDate = txtBirthDate.Text;
            string hireDate = txtHireDate.Text;
            string termDate = txtTermDate.Text;
            string employeeTypeId = drpEmployeeType.SelectedItem.Value;
            string gender = drpGender.SelectedItem.Text;
            string notes = txtNotes.Text;
            string personId = hidPersonId.Value;
            string instructorId = hidInstructorId.Value;

            Instructor instructorToSave = new Instructor();

            instructorToSave.InstructorId = instructorId.ToInt();
            instructorToSave.PersonId = personId.ToInt();

            //Nores: Specify person properties 

            instructorToSave.FirstName = firstName;
            instructorToSave.DisplayFirstName = preferedFirstName;
            instructorToSave.LastName = lastName;
            instructorToSave.BirthDate = birthDate.ToDate() ;
            instructorToSave.Gender = gender;


            // Specify Instructor properties.

            instructorToSave.HireDate = hireDate.ToDate();
            instructorToSave.TermDate = termDate.ToDate();
            instructorToSave.Description = notes;
            instructorToSave.EntityTypeId = employeeTypeId.ToInt();

            //Call the instructorManager class

           InstructorManager.Save(instructorToSave);
            if(instructorToSave.InstructorId > 0)
            base.DisplayPageMessage(lblPageMessage, "Update was successful!");
            else
            {
                Response.Redirect("InstructorList.aspx");
            }
            
            txtFirstName.Text = "";
            txtPreferedFirstName.Text = "";
            txtLastName.Text = "";
            txtBirthDate.Text = "";
            txtHireDate.Text = "";
            txtTermDate.Text = "";
            txtNotes.Text = "";
            drpGender.ClearSelection();
            drpEmployeeType.ClearSelection();

            //lblPageMessage.Text = formValues.ToString();

        }

        private void CheckUpdate()
        {
            if(base.InstructorId > 0)
            {
                Instructor instructorToUpdate = InstructorManager.GetItem(base.InstructorId);

                if(instructorToUpdate != null)
                {
                    this.BindUpdateInfo(instructorToUpdate);
                    this.SetButtons(true);
                }
                else
               
                    this.SetButtons(false);               
            }
            else
            
                this.SetButtons(false);            
        }

        private void BindInstructorNavigation()
        {
            // Set custom user control for instructor subheader navigation

            instructorNavigation.CurrentNavigationLink = InstructorNavigation.InstructorForm;

            instructorNavigation.InstructorId = Request.QueryString["InstructorId"].ToInt();
       
        }

        private void BindEmployeeType()
        {
            EntityTypeCollection employeeList = EntityTypeManager.GetCollection(Models.Enums.EntityEnum.EmployeeType);
            drpEmployeeType.DataSource = employeeList;
            drpEmployeeType.DataBind();

           drpEmployeeType.Items.Insert(0, new ListItem { Text = "Select Employee Type", Value ="0"});
        }

        private void BindUpdateInfo(Instructor instructorToUpdate)
        {
            if (instructorToUpdate.FirstName != null)
                txtFirstName.Text = instructorToUpdate.FirstName;

            if (instructorToUpdate.DisplayFirstName != null)
                txtPreferedFirstName.Text = instructorToUpdate.DisplayFirstName;

            if (instructorToUpdate.LastName != null)
                txtLastName.Text = instructorToUpdate.LastName;

            if (instructorToUpdate.Description != null)
                txtNotes.Text = instructorToUpdate.Description;

            if (instructorToUpdate.BirthDate != DateTime.MinValue)
                txtBirthDate.Text = instructorToUpdate.BirthDate.ToShortDateString();

            if (instructorToUpdate.HireDate != DateTime.MinValue)
                txtHireDate.Text = instructorToUpdate.HireDate.ToShortDateString();

            if (instructorToUpdate.TermDate != DateTime.MinValue)
                txtTermDate.Text = instructorToUpdate.TermDate.ToShortDateString();

            // Drop Down 
            if (instructorToUpdate.EntityTypeId > 0)
                drpEmployeeType.SelectedValue = instructorToUpdate.EntityTypeId.ToString();

            if (instructorToUpdate.Gender != null)
                drpGender.SelectedValue = instructorToUpdate.Gender;

            // Hidden fields to holdinstructor Id and PersonId

            hidInstructorId.Value = base.InstructorId.ToString();
            hidPersonId.Value = instructorToUpdate.PersonId.ToString();
        }

        private void SetButtons(bool isUpdate)
        {
            if(isUpdate)
            {
                //Update the text of the button
                btnSave.Text = "Update Instructor";
                btnSave.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                btnSave.Text = "Add Instructor";
                btnSave.Visible = true;
                btnCancel.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void DeleteInstructor()
        {
            int instructorId = hidInstructorId.Value.ToInt();

            if (instructorId > 0)
            {
                // Call middle tier to delete record

                if (InstructorManager.Delete(instructorId))
                {
                    //Redirect to instructor list
                    Response.Redirect("InstructorList.aspx");
                }
                else
                    base.DisplayPageMessage(lblPageMessage, "Error. Delete failed");
            }
            else
                base.DisplayPageMessage(lblPageMessage, "Invalid ID. Delete failed");
        }
       
       
    }
   

}