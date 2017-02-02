using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Webforms;

namespace VelocityCoders.FitnessSchedule.WebForms.UserControls
{
    public partial class LookupTablesNavigationControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.BindNavigationDropDown();
                this.BindCurrentNavigation();
                
            }
        }
        #region PROPERTIES
        /// <summary>
        /// Set the current lookup tables page. Property is of type LookupTablesNavigation enum specified 
        /// in the Enum.cs file
        /// </summary>
        public LookupTablesNavigation CurrentNavigationLink { get; set; }

        #endregion

        #region EVENT HANDLERS

        protected void LookupTables_Selected(object sender, EventArgs e)
        {
            if(drpSelectedLookupTable.SelectedValue != "0")
            {
                Response.Redirect(drpSelectedLookupTable.SelectedValue + "Lookup.aspx");
            }
        }
        #endregion

        #region BIND CONTROLS

        private void BindCurrentNavigation()
        {
            if(this.CurrentNavigationLink != LookupTablesNavigation.None)
            {
                drpSelectedLookupTable.SelectedValue = this.CurrentNavigationLink.ToString();
            }
        }
        /// <summary>
        /// Attempts to retrieve navigation items from web.config file
        /// and display in drop-down list.
        /// </summary>
        /// 
        private void BindNavigationDropDown()
        {
            //get values from web.config file
            string configItems = Utilities.GetApplicationKeyValue("LookupTablesNavigationItems");

            if(string.IsNullOrEmpty(configItems))
            {
                drpSelectedLookupTable.Items.Add("Not Available");
            }
            else
            {
                //parse by comma
                string[] navItems = configItems.Split(',');

                ListItemCollection collection = new ListItemCollection();

                //replacing any spaces in navigation item for value property
                foreach (string item in navItems)
                    collection.Add(new ListItem { Text = item, Value = item.Replace(" ", "") });

                drpSelectedLookupTable.DataSource = collection;
                drpSelectedLookupTable.DataBind();

                if (this.CurrentNavigationLink != LookupTablesNavigation.None)
                    drpSelectedLookupTable
                        .Items.Insert(0, new ListItem { Text = "(Select Lookup Table)", Value = "0" });

            }
        }
        #endregion
    }
}