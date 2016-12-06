using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Manager;
using VelocityCoders.FitnessSchedule.Models.Collections;
using VelocityCoders.FitnessSchedule.Models.Enums;
using VelocityCoders.FitnessSchedule.Models;
using Jagtap.Common.Extensions;
using VelocityCoders.FitnessSchedule.BLL;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin.InstructorFolder
{
    public partial class ContactInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                this.BindInstructorNavigation();
            }
            else
            {
                this.BindInstructorNavigation();
                this.BindEmailType();
                this.BindEmailList();
               
            }
          
        }

        #region BIND CONTROLS
        private void BindEmailList()
        {
            EmailAddressCollection emailList = EmailAddressManager.GetCollection(base.InstructorId);

            rptEmailList.DataSource = emailList;
            rptEmailList.DataBind();
        }

        private void BindInstructorNavigation()
        {
            instructorNavigation.CurrentNavigationLink = InstructorNavigation.ContactInfo;

            instructorNavigation.InstructorId = base.InstructorId;
        }

        private void BindEmailType()
        {
            EntityTypeCollection items = EntityTypeManager.GetCollection(EntityEnum.EmailType);

            drpEmailType.DataSource = items;
            drpEmailType.DataBind();

            drpEmailType.Items.Insert(0, new ListItem { Text = "Select Email Type", Value = "0" });
        }

        private void BindUpdateInfo(int emailId)
        {
            EmailAddress emailAddress = EmailAddressManager.GetItem(emailId);

            if (emailAddress != null)
            {
                hdnEmailId.Value = emailAddress.EmailId.ToString();

                if (emailAddress.EmailValue != null)
                    txtEmailAddress.Text = emailAddress.EmailValue;

                if (emailAddress.EmailType != null)
                    drpEmailType.SelectedValue = emailAddress.EmailType.EntityTypeId.ToString();

                SaveButton.Text = "Save Email";
            }
            else
                this.DisplayLocalMessage("Email Address could not be retrieved. Contact an administrator");
        }

        private void DisplayLocalMessage(string message)
        {
            
            this.DisplayLocalMessage(message, new BrokenRuleCollection());
        }

        private void DisplayLocalMessage(string message, BrokenRuleCollection brokenRules)
        {
            CustomMessageArea.Visible = true;
            CustomMessageArea.Message = message;

            if (brokenRules.Count() > 0)
                CustomMessageArea.BrokenRules = brokenRules;

            // Executes Display() method to render to screen
            CustomMessageArea.Display();
        }

        #endregion

        private void DeleteEmail(int emailId)
        {
            try
            {
                if(EmailAddressManager.Delete(emailId))
                    {
                    Response.Redirect("ContactInfo.aspx?InstructorId=" + base.InstructorId.ToString());
                    }
                else
                {
                    this.DisplayLocalMessage("Delete of Email failed. Contact Administrator.");
                }
            }
            catch(BLLException ex)
            {
                if (ex.BrokenRules != null && ex.BrokenRules.Count() > 0)
                    this.DisplayLocalMessage(ex.Message, ex.BrokenRules);
                else
                    this.DisplayLocalMessage(ex.Message);
            }
        }

        private void ProcessEmail()
        {
            EmailAddress emailToSave = new EmailAddress(drpEmailType.SelectedValue.ToInt(), txtEmailAddress.Text);

            // set emailId property for updates
            emailToSave.EmailId = hdnEmailId.Value.ToInt();
            try
            {
                //Call middle tier to save
                InstructorManager.SaveEmail(base.InstructorId, emailToSave);

                Response.Redirect("ContactInfo.aspx?InstructorId=" + base.InstructorId.ToString());

            }
            catch(BLLException ex)
            {
                if (ex.BrokenRules != null && ex.BrokenRules.Count() > 0)
                    this.DisplayLocalMessage(ex.Message, ex.BrokenRules);
                else
                    this.DisplayLocalMessage(ex.Message);
            }

        }

        #region EVENT HANDLERS
        protected void EmailList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                EmailAddress emailAddress = (EmailAddress)e.Item.DataItem;

                LinkButton editButton = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("DeleteButton");

                editButton.CommandArgument = emailAddress.EmailId.ToString();
                deleteButton.CommandArgument = emailAddress.EmailId.ToString(); 
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            this.ProcessEmail();
        }

        protected void EmailButton_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    this.BindUpdateInfo(e.CommandArgument.ToString().ToInt());
                    break;
                case "Delete":
                    this.DeleteEmail(e.CommandArgument.ToString().ToInt());
                    break;
            }
        }

       
        #endregion

    }
}