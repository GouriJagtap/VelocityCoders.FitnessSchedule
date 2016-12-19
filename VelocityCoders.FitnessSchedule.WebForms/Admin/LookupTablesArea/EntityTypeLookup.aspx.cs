using Jagtap.Common;
using Jagtap.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Webforms;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin.LookupTablesArea
{
    public partial class EntityTypeLookup : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetMasterPageNavigation(MasterNavigation.LookupTables);
            this.BindNavigation();

            if(!IsPostBack)
            {
                this.BindEntityDropDown();
                if(base.EntityId >0)
                {
                    this.DisplayFormSave(true);
                    this.BindEntityTypeList(base.EntityId);
                }
            }
        }

        #region PROCESS

        private void DeleteItem(int entityTypeId)
        {
            using (ServiceEntityLookup.EntityTypeLookupServiceClient entityLookService =
                new ServiceEntityLookup.EntityTypeLookupServiceClient())
            {
                try
                {
                    entityLookService.DeleteEntityType(entityTypeId);
                    this.ReloadPage(drpEntity.SelectedValue.ToInt());
                }
                catch(FaultException<ServiceEntityLookup.EntityLookupServiceFault> ex)
                {
                    this.DisplayLocalMessage(ex.Message + " " + ex.Detail.ErrorMrssage);
                }
            }
        }
        private void DisplayFormSave(bool isVisible)
        {
            EntityNameTableRow.Visible = isVisible;
            EntityDisplayNameTableRow.Visible = isVisible;
            SaveButton.Visible = isVisible;
            rptLookupList.Visible = isVisible;
        }
        private void ProcessForm()
        {
            ServiceEntityLookup.EntityTypeDTO itemToSave = new ServiceEntityLookup.EntityTypeDTO();

            itemToSave.EntityId = drpEntity.SelectedValue.ToInt();
            itemToSave.EntityTypeName = txtEntityName.Text.Trim();
            itemToSave.DisplayName = txtEntityDisplayName.Text.Trim();

            if (HiddenEntityTypeId.Value.ToInt() > 0)
                itemToSave.EntityTypeId = HiddenEntityTypeId.Value.ToInt();

            using (ServiceEntityLookup.EntityTypeLookupServiceClient entityLookupService =
                new ServiceEntityLookup.EntityTypeLookupServiceClient())
            {
                try
                {
                    entityLookupService.SaveEntityType(itemToSave);

                    this.ReloadPage(drpEntity.SelectedValue.ToInt());
                }
                catch(FaultException<ServiceEntityLookup.EntityLookupServiceFault> ex)
                {
                    this.DisplayLocalMessage(ex.Message + " " + ex.Detail.ErrorMrssage);
                }
            }
        }
        private void ReloadPage()
        {
            this.ReloadPage(0);
        }
        private void ReloadPage(int entityId)
        {
            if (entityId > 0)
                Response.Redirect("EntityTypeLookup.aspx?EntityId=" + entityId.ToString());
            else
                Response.Redirect("EntityTypeLookup.aspx");
        }
        private bool ValidateForm()
        {
            bool returnValue = true;
            BrokenRuleCollection brokenRules = new BrokenRuleCollection();

            if(drpEntity.SelectedValue.Trim().ToInt() == 0)
            {
                brokenRules.Add("Entity", "Please select a valid Entity from the drop-down list");
                returnValue = false;
            }
            if(string.IsNullOrEmpty(txtEntityName.Text.Trim()))
            {
                brokenRules.Add("Lookup Name", "Required Field");
                returnValue = false;
            }
            if(!returnValue)
            {
                if (brokenRules.Count() == 1)
                    this.DisplayLocalMessage("There is an error with your submission. Please correct and try again", brokenRules);
                else
                    this.DisplayLocalMessage("There were some errors with your submission. Please correct and try again.", brokenRules);
            }
            return returnValue;
        }
        #endregion

        #region BIND CONTROLS

        private void BindEntityDropDown()
        {
            using (ServiceEntityLookup.EntityTypeLookupServiceClient entityLookupService =
                new ServiceEntityLookup.EntityTypeLookupServiceClient())
            {
                ServiceEntityLookup.EntityDTOCollection entityCollection = entityLookupService.GetEntityCollection();
                if (entityCollection != null && entityCollection.Count() > 0)
                {
                    drpEntity.DataSource = entityCollection;
                    drpEntity.DataBind();

                    drpEntity.Items.Insert(0, new ListItem { Text = "(Select Entity)", Value = "0" });

                    drpEntity.SelectedValue = base.EntityId.ToString();

                }
                else
                    drpEntity.Items.Add(new ListItem { Text = "Not Available", Value = "0" });
            }
        }
        private void BindEntityTypeList(int entityId)
        {
            if(entityId >0)
            {
                using (ServiceEntityLookup.EntityTypeLookupServiceClient entityLookupService =
                    new ServiceEntityLookup.EntityTypeLookupServiceClient())
                {
                    ServiceEntityLookup.EntityTypeDTOCollection entityTypeCollection =
                        entityLookupService.getEntityTypeCollection(entityId);
                    if(entityTypeCollection != null)
                    {
                        rptLookupList.DataSource = entityTypeCollection;
                        rptLookupList.DataBind();
                    }
                }
            }
        }

        private void BindNavigation()
        {
            lookupTablesNavigation.CurrentNavigationLink = LookupTablesNavigation.EntityType;
        }
        private void BindUpdateInfo(int entityTypeId)
        {
            using (ServiceEntityLookup.EntityTypeLookupServiceClient entityLookupService =
                new ServiceEntityLookup.EntityTypeLookupServiceClient())
            {
                try
                {
                    ServiceEntityLookup.EntityTypeDTO itemToUpdate = entityLookupService.GetEntityType(entityTypeId);

                    if (itemToUpdate != null)
                    {
                        HiddenEntityTypeId.Value = itemToUpdate.EntityTypeId.ToString();

                        if (!string.IsNullOrEmpty(itemToUpdate.EntityTypeName))
                            txtEntityName.Text = itemToUpdate.EntityTypeName;

                        if (!string.IsNullOrEmpty(itemToUpdate.DisplayName))
                            txtEntityDisplayName.Text = itemToUpdate.DisplayName;

                        SaveButton.Text = "Update Lookup Value";

                        btnCancel.Visible = true;
                    }
                    else
                        this.DisplayLocalMessage("Update failed. Couldn't find record.");
                }
                catch(FaultException<ServiceEntityLookup.EntityLookupServiceFault> ex)
                {
                    this.DisplayLocalMessage(ex.Message + " " + ex.Detail.ErrorMrssage);
                }
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

        #region EVENT HANDELERS

        protected void Cancel_Click(Object sender, EventArgs e)
        {
            this.ReloadPage(drpEntity.SelectedValue.ToInt());
        }
        protected void EntityList_Selected(Object sender, EventArgs e)
        {
            if (drpEntity.SelectedValue.ToInt() > 0)
            {
                this.DisplayFormSave(true);
                this.BindEntityTypeList(drpEntity.SelectedValue.ToInt());
            }
            else
            {
                this.DisplayFormSave(false);
            }
        }
        protected void EntityTypeButton_Command(Object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    this.BindUpdateInfo(e.CommandArgument.ToString());
                    break;
                case "Delete":
                    this.DeleteItem(e.CommandArgument.ToString().ToInt());
                    break;
            }
        }

        private void BindUpdateInfo(string v)
        {
            throw new NotImplementedException();
        }

        protected void LookupList_OnItemDataBound(Object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ServiceEntityLookup.EntityTypeDTO entityType = (ServiceEntityLookup.EntityTypeDTO)e.Item.DataItem;

                LinkButton editButton = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("DeleteButton");

                editButton.CommandArgument = entityType.EntityTypeId.ToString();
                deleteButton.CommandArgument = entityType.EntityTypeId.ToString();
            }
        }
        protected void Save_Click(Object sender, EventArgs e)
        {
            if (this.ValidateForm())
                this.ProcessForm();
        }

        #endregion


    }
}