using Jagtap.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessSchedule.WebForms
{
    public class BasePage : System.Web.UI.Page
    {
        #region PROPERTIES

        public int InstructorId
        {
            get
            {
                return this.GetQuerryStringNumber("InstructorId");
            }
        }
        #endregion

        /// <summary>
        ///Attempt to retrieve a numeric value from the 'querystring'
        ///If invalid queryString name or value is not an integer, returns 0
        /// </summary>
        /// <param name="queryStringName"></param>
        /// <returns>Integer value</returns>
        /// 

        public int GetQuerryStringNumber(String queryStringName)
        {
            if (Request.QueryString[queryStringName] == null)
            {
                return 0;
            }
            else
            {
                return Request.QueryString[queryStringName].ToInt();
            }

        }

        /// <summary>
        /// Pass in the <asp:Label> control to set its txt property. Set isAppend
        /// to true if you want the message to be concatenated</Label>
        /// </summary>
        /// <param name="lableControl"></param>
        /// <param name="messageToDisplay"></param>
        /// 
        public void DisplayPageMessage(Label lableControl, string messageToDisplay)
        {
            this.DisplayPageMessage(lableControl, messageToDisplay, false);

        }
        public void DisplayPageMessage(Label labelControl, string messageToDisplay, bool isAppend)
        {
            if (isAppend)
                labelControl.Text += messageToDisplay;
            else
                labelControl.Text = messageToDisplay;
        }

    }
   
}