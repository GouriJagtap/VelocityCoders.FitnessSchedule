using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jagtap.Common.Helpers;


namespace VelocityCoders.FitnessSchedule.WebForms
{
    public partial class D_04_Instance_vs_Static_LAB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //notes:    form is posted to server/code-behind
                try
                {
                    lblDisplayMessage1.Text = string.Empty;

                    int choice = Convert.ToInt32(TextBox1.Text);
                    //TextBox2.Text = string.Empty;
                    if (choice == 1)
                    {
                        string temp = TextBox2.Text.ToString();
                        double fahreinheit = TemprratureConverter.CelsiusToFahrenheit(temp);
                        lblDisplayMessage1.Text = fahreinheit.ToString();
                        
                        TextBox1.Text = string.Empty;
                       
                    }
                    else
                    {
                        string temp = TextBox2.Text.ToString();
                        double celsius = TemprratureConverter.FahrenheitToCelsius(temp);
                        lblDisplayMessage1.Text = celsius.ToString();
                        TextBox1.Text = string.Empty;
                    }
             
                }

                catch (Exception E)
                {
                    lblDisplayMessage1.Text = E.Message;
                }
              
                finally
                {
                    TextBox2.Text = string.Empty;
                }
            }
        }

    }
}