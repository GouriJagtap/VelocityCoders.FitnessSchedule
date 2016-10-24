using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.LotteryGame.WebForms;

namespace VelocityCoders.FitnessSchedule.WebForms
{
    public partial class ConditiolanStatements : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ConditionalStatentExample();
            this.SwitchExample();
            //B_04_Arrays_LAB myArray = new B_04_Arrays_LAB();
            //myArray.ArrayExample();
            
        }

        private void ConditionalStatentExample()
        {
            //int x = 1;
            //string fName = "Jane";
            //Boolean isDeleted = true;
            //string outputMessage;

            //if (!isDeleted)

            //if(fName == "Jane" && x>10)

            //if (x > 15)
            //{
            //    outputMessage = "Greater than 15";
            //    outputMessage = "yes";
            //    x = 14;
            //}
            //else if (x>10)
            //{
            //    outputMessage = "No";

            //    outputMessage = "Less than 15";
            //}
            //else
            //{
            //    lblOutputMessage.Text = "Dont Know";
            //}
            //lblOutputMessage.Text = outputMessage;

            //int y = 2;
            #region SwitchStatement
            //switch(y)
            //{
            //    case 1:
            //    case 2:
            //        outputMessage = "1 or 2 was the value";
            //        break;
            //    case 20:
            //        outputMessage = y.ToString();
            //        break;
            //    case 30:
            //        outputMessage = y.ToString();
            //        break;
            //    default:
            //        outputMessage = "Nothing Matched";
            //        break;
            //}
            //lblOutputMessage1.Text = outputMessage;
            #endregion

            #region  IfStatementwithOperators 
            int z = 12;
            string newVAlue = (z > 15) ? "Greater that 15" : "Less than 15";
            lblOutputMessage.Text = newVAlue;

            string firstVariable = "Hi";
            string secondVariable = "Bye";


            if (firstVariable == secondVariable)
            {
                lblOutputMessage1.Text = firstVariable + " and " + secondVariable + "  are equal";
            }
            else
            {
                lblOutputMessage1.Text = firstVariable + " and " + secondVariable + "  are  not equal";
            }


            int intVariable01 = 10;
            int intVariable02 = 50;

            if (intVariable01 >= intVariable02)
            {
                lblOutputMessage2.Text = intVariable01.ToString() + " is greater than " + intVariable02.ToString();
            }
            else
            {
                lblOutputMessage2.Text = intVariable01.ToString() + " is less than " + intVariable02.ToString();
            }


            if (firstVariable == secondVariable && intVariable01 <= intVariable02)
            {
                lblOutputMessage3.Text = "Both conditions are true";
            }
            if (firstVariable == secondVariable || intVariable01 <= intVariable02)
            {
                lblOutputMessage3.Text = "Atlease one condition is true";
            }

            string outputMessage = string.Empty;
            int yourAge = 30;

            //Nested if statement
            if(yourAge > 50 )
            {
                outputMessage = "You are Old";
            }
            else
            {
              
                if (yourAge >=11 && yourAge <=19)
                {
                    outputMessage = "Wild teenage years";
                }
                else
                {
                    outputMessage = "Still a young pup";
                }
            }

            //If/Else If

            outputMessage = string.Empty;
            int yourAge1 = 30;

            if (yourAge1 >50)
            {
                outputMessage = "You are old";
            }
            else if(yourAge1 >= 11 && yourAge1 <=19)
            {
                outputMessage = "Wild Teenage Years";
            }
            else
            {
                outputMessage = "Still a young pup";
            }
            lblOutputMessage4.Text = outputMessage;
            #endregion

            #region ConditionalOperator

            int yourAge2 = 20;
            outputMessage = (yourAge2 > 50) ? "You are old" : "Still young";
            lblOutputMessage1.Text = outputMessage;
            #endregion

            #region Null-Coalescing operator
            //string nullVariable = null;
            //outputMessage = nullVariable ?? "Value is null";

            String nullVariable = "This variable is set to a value other than null";
            outputMessage = nullVariable ?? "Value is Null";
            lblOutputMessage5.Text = outputMessage;
            #endregion

            #region SWITCH statement

            string stateName = "Minnesota";

            switch(stateName)
            {
                case "California":
                case "Oregon":
                    outputMessage = "Hi from WestCoast!";
                break;

                case "Minnesota":
                case "Iowa":
                case "Wisconsin":
                    outputMessage = "You are in Midwest";
                break;

                case "New Your":
                case "Maryland":
                    outputMessage = "East Coast Pride!";
                break;

                default:
                    outputMessage = "Somewhere else in the US ";
                break;

            }
            lblOutputMessage3.Text = outputMessage;

            #endregion
        }
        private void SwitchExample()
        {
            String userInput = txtCarMake.Text;
            string outputMessage = string.Empty;

            switch (userInput.ToUpper())
            {
                case "HONDA":
                case "TOYOTA":
                    outputMessage = "Japenese Vehicle";
                break;

                case "BMW":
                case "Mercedes Benz":
                case "VolksWagen":
                case "Jaguar":
                    outputMessage = "European Vehicle";
                break;

                case "CHEVY":
                case "FORD":
                    outputMessage = "Americal Vehicle";
                break;

                default:
                    outputMessage = "I dont know where your car is from";
                break;
            }
            lblDisplayMessage6.Text = "Your input : " + userInput + " " + outputMessage; 
        }
    }
    }
