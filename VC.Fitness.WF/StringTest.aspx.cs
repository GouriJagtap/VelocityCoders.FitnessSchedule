using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessSchedule.WebForms
{
    public partial class StringTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fullName = GetFullName("Gouri", "Jagtap");
            int age = 30;
            string convertAge = age.ToString();
            string subStringValue = fullName.Substring(0, 5);
            lblDisplayName.Text = subStringValue + " "+ convertAge;
            Strings();

        }
        private void Strings()
        {
            string firstName;
            String lastName;
            System.String middleName;
            int age = 30;
            string convertAge = age.ToString();
            string compareString01 = "Sample Text";
            string compareString02 = "Sample Text";
            if (String.Compare(compareString01, compareString02) == 0)
            {
                // Strings are equal
                lblCompareStrings.Text = "Strings are equal";
            }
            else
            {
                // Strings are not equal
                lblCompareStrings.Text = "Strings are not equal";
            }
            //Check to see if the string is null or empty

            string checkStringNull = "Something";
            if (string.IsNullOrEmpty(checkStringNull))
            {
                // the string is empty
                lblIsEmpty.Text = "The String is Enpty or NULL";
            }
            else
            {
                // the string is not empty
                lblIsEmpty.Text = "The String is not Enpty or NULL";
            }

            //String vs StringBuilder
            string  updateString = "Happy Programming";
            updateString = "Some new Text";
            lblLoopString.Text = updateString;
            //Loop through the updateString 
            String loopSrting = "count";
            for(int i=0; i<=20; i++)
            {
                loopSrting = loopSrting + " " + i.ToString();
                  lblLoopString.Text = loopSrting;
            }
            // using StringBuilder class
            StringBuilder sbLoopString = new StringBuilder();
            sbLoopString.Append("Count: ");
            for(int j= -20; j<-20; j++)
            {
                //Appedning the val;ue to the StringBuilder object
                sbLoopString.Append(j.ToString());
                lblStringBuilderLoop.Text = sbLoopString.ToString();
            }

        }
        private String GetFullName(String s1, String s2)
        {
            return s1 + " " + s2;
        }
    }
}