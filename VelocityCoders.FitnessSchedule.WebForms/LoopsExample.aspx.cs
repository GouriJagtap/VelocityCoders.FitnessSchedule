using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessSchedule.WebForms
{
    public partial class LoopsExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoopExample();
        }
        private void LoopExample()
        {
            #region FOR LOOP

            //For Loop 
            StringBuilder sb = new StringBuilder();
            for( int x= 1; x<=10; x++)
            {
                sb.Append("Loop Iteration:" + x.ToString() + "<br>");
            }
            #endregion


            #region FOREACH LOOP
            sb = new StringBuilder();
            string[] nameList = new string[] { "Amy", "Bill", "Micheal", "Bobby", "Darin" };
            Array.Sort(nameList);

            foreach(String item in nameList)
            {
                sb.Append("Iteration : " + item + "<br>");
            }

            #endregion

            #region WHILE LOOP

            int[] intArray = new int[10]; //{ 2,4,6,8,10,12,0};
            intArray[0] = 2;
            intArray[1] = 4;
            intArray[2] = 6;
            intArray[3] = 8;
            intArray[4] = 10;
            intArray[5] = 12;
            intArray[6] = 14;


            bool keepGoing = true;
            int count = 0;
            sb = new StringBuilder();

            // Loop through untill the boolean variable keepGoing is false

            while (keepGoing)
            {
                sb.Append(intArray[count].ToString() + "<BR>");

                // Condition = if it finds the value of 0 top loop

                keepGoing = (intArray[count] == 0) ? false : true;

                //Increment counter

                count++;

            }
            #endregion

            //#region DO LOOP

            //int y = 0;
            //sb = new StringBuilder();

            //do
            //{
            //    sb.Append(y.ToString() + "<Br>");
            //    y++;
            //} while (y < 5);

            //#endregion

            lblDisplayMessage1.Text = sb.ToString();
        }


    }
}