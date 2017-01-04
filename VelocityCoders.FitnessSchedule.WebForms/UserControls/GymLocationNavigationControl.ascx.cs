using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace VelocityCoders.FitnessSchedule.WebForms.UserControls
{
    public partial class GymLocationNavigationControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.BindCurrentNavigation();
                this.BindNavigationDropDown();
            }
        }

            #region PROPERTIES
            /// <summary>
            /// Set the current lookup tables page. Property is of type
            /// LookupTablesNavigation enum specified in the Enum.cs file
            /// </summary>
            public GymLocationNavigation CurrentNavigationLink { get; set; }

            #endregion

            #region BIND CONTROLS
        /// <summary>
        /// Attempts to retrieve navigation items from web.config file. 
        /// And display in dropdown list
        /// </summary>
        private void BindNavigationDropDown()
        {
            string configItems = Utilities.GetApplicationKeyValue("GymLocationNavigationItems");

            if(string.IsNullOrEmpty(configItems))
            {
                drpSelectionGymLocation.Items.Add("Not Available");

            }
            else
            {
                string[] navItems = configItems.Split(',');

                ListItemCollection collection = new ListItemCollection();

                foreach (string item in navItems)
                    collection.Add(new ListItem { Text = item, Value = item.Replace(" ", "") });

                drpSelectionGymLocation.DataSource = collection;
                drpSelectionGymLocation.DataBind();

                if (this.CurrentNavigationLink == GymLocationNavigation.None)
                    drpSelectionGymLocation.Items.Insert(0, new ListItem { Text = "Select Section", Value = "0" });

            }
        }

        /// <summary>
        /// Attempts to pre select item in drop down list if control's 
        /// currentNavigation property is set
        /// </summary>
        private void BindCurrentNavigation()
        {
            if(this.CurrentNavigationLink != GymLocationNavigation.None)
            {
                drpSelectionGymLocation.SelectedValue = this.CurrentNavigationLink.ToString();
            }
        }
            #endregion

            #region EVENT HANDELERS
            
        protected void GymLocation_Selected(object sender, EventArgs e)
        {
            if(drpSelectionGymLocation.SelectedValue != "0")
            {
                Response.Redirect(drpSelectionGymLocation.SelectedValue + "Manage.aspx");
            }
        }

            #endregion
        }
    
}