using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessSchedule.WebForms
{
    public partial class ArrayExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ArrayExamples();
        }
        private void ArrayExamples()
        {
            string[] nameList = new string[10];
            nameList[0] = "Andy";
            nameList[1] = "Sammy";
            nameList[2] = "Abby";
            nameList[3] = "Cathey";
            nameList[4] = "Bob";

            lblDisplayArray1.Text = "Element 1 of Array :" + string.Concat(nameList);
            

            int[] ageList = new int[] { 42, 23, 45, 22, 32, 55 };

            Array.Sort(ageList);
            Array.Sort(nameList);
            lblDisplayArray1.Text = "Element 1 of Array :" + string.Join(", ", nameList);
            lblDisplayArray2.Text = "All Elements : " + string.Join(", ", ageList);


            String[] firstStringArray = new string[4];
            firstStringArray[0] = "First";
            firstStringArray[1] = "Second";
            firstStringArray[2] = "Third";
            firstStringArray[3] = "Fourth";

            lblDisplayArray3.Text = "Elements of firstStringArray are: " + string.Join(", " , firstStringArray);
       
        }
    }
}