using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jagtap.Common;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;
using Jagtap.Common.Helpers;
using Jagtap.Common.Extensions;
using VelocityCoders.FitnessSchedule.Models.Enums;

namespace VelocityCoders.FitnessSchedule.WebForms
{
    public partial class HelloWorld1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String fullName = this.GetFullName("Jim", "Brown");
            //this.DisplayName(lblDisplayMessage, "Full Name : "+ fullName);
            //lblDisplayMessage.Text = this.GetStateName(1);
            //lblDisplayMessage1.Text = this.GetStateName("AZ");
            //this.PolymorphismExample();
            //this.InterfaceExample();

            ////Decoupling of classes
            //Student stndt = new Student()
            //{
            //    FirstName = "John",
            //    LastName = "Smith",
            //    JoinDate = new DateTime(2010, 10, 5)
            //};
            //this.InterfaceExample(stndt);

            //Instructor inst = new Instructor()
            //{
            //    FirstName = "Katie",
            //    LastName = "Duffy",
            //    HireDate = new DateTime(2008, 1, 23)
            //};
            //this.InterfaceExample(inst);

            this.StaticExample();

            //this.ExtensionExample();

            this.EnumExample();
        }
        //Static Polymorphism Method OverLoading

        private string GetStateName(int stateId)
        {
            string returnValue = string.Empty;
            switch(stateId)
            {
                case 1:
                    returnValue = "Alabama";
                    break;
                case 2:
                    returnValue = "Alaska";
                    break;

            }
            return returnValue;
        }

        private string GetStateName(string stateAbbreviation)
        {
            string returnValue = string.Empty;
            switch (stateAbbreviation)
            {
                case "AZ":

                    returnValue = "Arizona";
                    break;

                case "AR":

                    returnValue = "Arkansas";
                    break;
            }
             return returnValue;
            
        }

        //Dynamic Polymorphism Method overriding 

            private void PolymorphismExample()
        {
            Person newPerson = new Person() {firstName = "Julie", lastName = "Mane"};
            lblDisplayMessage.Text =  newPerson.GetName1();
        }

        private void DisplayName(Label labelControl, String displayMessage)
        {
            labelControl.Text = displayMessage;
        }

        private string GetFullName(String firstName, String lastName)
        {
            String fullName= firstName + "" + lastName;
            return fullName;
        }

        private void InterfaceExample(IPerson person)
        {

            //Instructor inst = new Instructor()
            Student stnt = new Models.Student()
            {
                FirstName = "John",
                LastName = "Duffy",
                //HireDate = new DateTime(2009,12,1)
                JoinDate = new DateTime(2006, 10, 1)
            };
            lblDisplayMessage.Text = stnt.GetFullInfo();

            lblDisplayMessage.Text = person.GetFullInfo();
        }

        private void StaticExample()
        {
            lblDisplayMessage.Text = StateHelper.GetStateName("MN");
            
        }

        private void ExtensionExample()
        {
            string myBirthday = "2/1/1990";
            DateTime convertDate = myBirthday.ToDate();
            lblDisplayMessage1.Text = convertDate.ToString();

            string myAge = "20";
            int convertAge = myAge.ToInt();

            lblDisplayMessage.Text = convertAge.ToString();

            string strn = "abjs";
            lblDisplayMessage2.Text = strn.GetFirstCharacter();

            DateTime JoinDate = new DateTime(2006, 10, 1);
            lblDisplayMessage1.Text= JoinDate.TellTime();




        }

        private void EnumExample()
        {
            lblDisplayMessage2.Text =((int)DaysEnum.Monday).ToString();
            lblDisplayMessage.Text = SelectSP.GET_COLLECTION.ToString();
            lblDisplayMessage1.Text = ((int)ExecuteSP.INSERT_ITEM).ToString();
           
        }
 

    }
}