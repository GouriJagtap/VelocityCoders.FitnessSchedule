using Jagtap.Common;
using Jagtap.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Webforms;
using VelocityCoders.FitnessSchedule.WebForms;
using VelocityCoders.FitnessSchedule.WebForms.Models;


namespace VelocityCoders.FitnessSchedule.WebForms.Admin.GymLocationArea
{
    public partial class GymManage : BasePage
    {
        private string _baseServiceURI = "http://localhost:51359/GymService/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGymList();
                this.SetMasterPageNavigation(MasterNavigation.GymLocation);
            }
        }
        #region PROCESS

        private void DeleteItem(int gymId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage responseMessage =
                        httpClient.DeleteAsync(_baseServiceURI + "Gym/Item/" + gymId.ToString()).Result)
                {
                    if (responseMessage.IsSuccessStatusCode)
                        this.ReloadPage();
                    else
                        this.DisplayLocalMessage("There was an error deleting this Gym record");
                }
            }
        }

        private void ProcessForm()
        {
            GymDTO itemToSave = new GymDTO();
            string serviceURL = _baseServiceURI + "Gym/Item/";
            //string gymId = HiddenGymId.Value;
            if (HiddenGymId.Value.ToInt() > 0)
                itemToSave.Id = HiddenGymId.Value.ToInt();

            itemToSave.Name = txtGymName.Text.Trim();
            itemToSave.Abbreviation = txtGymAbbreviation.Text.Trim();
            itemToSave.WebSite = txtWebsite.Text.Trim();
            itemToSave.Description = txtDescription.Text.Trim();
            //itemToSave.CreateDate = txtCreateDate.Text.ToDate();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = httpClient.PutAsJsonAsync(serviceURL,itemToSave).Result) 
                {
                    if (responseMessage.IsSuccessStatusCode)
                        this.ReloadPage();
                    else
                        this.DisplayLocalMessage("There was an error saving this Gym record");
                }
            }
        }
        private void ReloadPage()
        {
            Response.Redirect("GymManage.aspx");
        }
        private bool ValidateForm()
        {
            bool returnValue = true;
            BrokenRuleCollection brokenRules = new BrokenRuleCollection();

            if (string.IsNullOrEmpty(txtGymName.Text.Trim()))
            {
                brokenRules.Add("Gym Name", "Required Field");
                returnValue = false;
            }
            if(!returnValue)
            {
                if (brokenRules.Count() == 1)
                    this.DisplayLocalMessage("There is an error with your submission. Please correct and try again", brokenRules);
                else
                    this.DisplayLocalMessage("There were some errors with your submission. Please correct and try again", brokenRules);
            }
            return returnValue;
        }
        #endregion

        #region BIND CONTROLS

        private void BindNavigation()
        {
            gymLocationNavigation.CurrentNavigationLink = GymLocationNavigation.Gym;
        }
        private void BindGymList()
        {
            using (WebClient webClient = new WebClient())
            {
                string json = webClient.DownloadString(_baseServiceURI + "Gym/Collection/");
                List<GymDTO> gymList = base.GetModelList<GymDTO>(json);

                if(gymList != null)
                {
                    rptGymList.DataSource = gymList;
                    rptGymList.DataBind();
                }
            }
        }
        private void BindUpdateInfo(int gymId)
        {
            using (WebClient webClient = new WebClient())
            {
                string json = webClient.DownloadString(_baseServiceURI + "Gym/Item/" + gymId.ToString());
                GymDTO itemToUpdate = base.GetModelItem<GymDTO>(json);

                if (itemToUpdate != null)
                {
                    HiddenGymId.Value = itemToUpdate.Id.ToString();

                    if (!string.IsNullOrEmpty(itemToUpdate.Name))
                        txtGymName.Text = itemToUpdate.Name;

                    if (!string.IsNullOrEmpty(itemToUpdate.Abbreviation))
                        txtGymAbbreviation.Text = itemToUpdate.Abbreviation;

                    if (!string.IsNullOrEmpty(itemToUpdate.WebSite))
                        txtWebsite.Text = itemToUpdate.WebSite;

                    if (!string.IsNullOrEmpty(itemToUpdate.Description))
                        txtDescription.Text = itemToUpdate.Description;

                    //if (itemToUpdate.CreateDate != DateTime.MinValue)
                    //    txtCreateDate.Text = itemToUpdate.CreateDate.ToShortDateString();


                    SaveButton.Text = "Update Gym";

                    btnCancel.Visible = true;

                }
                else
                    this.DisplayLocalMessage("Update failed. Couldn't find Gym record.");
            }
        }
        private void DisplayLocalMessage(string message)
        {
            this.DisplayLocalMessage(message, new BrokenRuleCollection());
        }

        private void DisplayLocalMessage(string message, BrokenRuleCollection brokenRules)
        {
            customMessageArea.Visible = true;
            customMessageArea.Message = message;

            if (brokenRules.Count() > 0)
                customMessageArea.BrokenRules = brokenRules;

            customMessageArea.Display();
        }
        #endregion

        #region EVENT HANDLERS

        protected void Cancel_Click(object sender, EventArgs e)
        {
            this.ReloadPage();
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (this.ValidateForm())
                this.ProcessForm();
        }

        protected void GymList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                GymDTO gymItem = (GymDTO)e.Item.DataItem;

                LinkButton editButton = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("DeleteButton");

                editButton.CommandArgument = gymItem.Id.ToString();
                deleteButton.CommandArgument = gymItem.Id.ToString();

            }
        }

        protected void GymButton_Command(object sender, CommandEventArgs e)
        {
            customMessageArea.Visible = false;

            switch(e.CommandName)
            {
                case "Edit":
                    this.BindUpdateInfo(e.CommandArgument.ToString().ToInt());
                    break;
                case "Delete":
                    this.DeleteItem(e.CommandArgument.ToString().ToInt());
                    break;

            }
        }
        #endregion
    }
}