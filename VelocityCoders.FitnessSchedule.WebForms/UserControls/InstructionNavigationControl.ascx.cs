using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessSchedule.WebForms.UserControls
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindInstructorNavigation();
        }
        #region Properties
        /// <summary>
        /// Set the current instructor page. Link will be disabled for the 
        /// current subheader link of current page.
        /// </summary>
       
        public InstructorNavigation CurrentNavigationLink { get; set; }

        /// <summary>
        /// If Id is greater than 0 we will activate the subheader links otherwise 
        /// all the subheader links will be inactive
        /// </summary>
        public int InstructorId { get; set; }

        #endregion

        #region Bind Controls
        /// <summary>
        /// 
        /// 
        /// </summary>
        private void BindInstructorNavigation()
        {

            //Notes: Set up collection of list items for links

            ListItemCollection navigationList = new ListItemCollection();

            //Notes: set array containing enum of instructor navigation values

            Array navigationValues = Enum.GetValues(typeof(InstructorNavigation));

            //Notes: set local variables

            string instructorIdQueryString = "InstructorId=" + this.InstructorId.ToString();

            if (InstructorId > 0)
            {
                foreach (InstructorNavigation item in navigationValues)
                {
                    if (item != InstructorNavigation.None)
                    {
                        string displayValue = item.ToString().Replace("_", " ");
                        string urlValue = item.ToString().Replace("_", " ");

                        if (item == this.CurrentNavigationLink)
                            navigationList.Add(new ListItem { Text = displayValue, Value = "", Enabled = false });
                        else
                            navigationList.Add(new ListItem
                            {
                                Text = displayValue,
                                Value = "/Admin/InstructorFolder/" + item.ToString() + ".aspx?" + instructorIdQueryString,
                                Enabled = true
                            });
                    }
                }
            }
            else
            {
                //notes: No InstructorId exists-set all links to inactive iterate over enum
                foreach (InstructorNavigation item in navigationValues)
                {
                    if (item != InstructorNavigation.None)
                    {
                        string displayValue = item.ToString().Replace("_", " ");
                        string urlValue = item.ToString().Replace("_", " ");

                        switch (item)
                        {

                            case InstructorNavigation.InstructorList:
                            case InstructorNavigation.InstructorForm:

                                navigationList.Add(new ListItem
                                {
                                    Text = displayValue,
                                    Value = "/Admin/InstructorFolder/" + urlValue + ".aspx",
                                    Enabled = true
                                 });
                        break;

                        default:

                        navigationList.Add(new ListItem
                        {
                            Text = displayValue,
                            Value = "/Admin/InstructorFolder/" + urlValue + ".aspx?" + instructorIdQueryString,
                            Enabled = false
                        });
                        break;
                       }
                    }
                }
            }
        
            //Bind the list objects to front end control

            InstructionNavigationList.DataSource = navigationList;
            InstructionNavigationList.DataBind();
        }
        #endregion
    }
}