using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;
using System.Text;
using Jagtap.Common;


namespace VelocityCoders.FitnessSchedule.WebForms
{
    public partial class HelloWorld : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String fullName = this.GetFullName("James", "Jones");
            this.DisplayMessage(lblDisplayMessage, "Full Name :" + fullName);
            int pageLoadx = 20;
            this.ByValueExample(pageLoadx);
            lblDisplayMessage.Text += "This is the value we are passing :" + pageLoadx.ToString() + "<br>";
            this.ByReferenceExample(ref pageLoadx);
            lblDisplayMessage.Text += "This is the value we are passing by reference :" + pageLoadx.ToString() + "<br>";
            //this.PersonExample();
            //this.InstructorExample();
            this.AbstractExample();
            //this.CollectionExample();
            //this.ExceptionExample();
        }

        private void DisplayMessage(Label labelControl, String displayMessage)
        {
            labelControl.Text = displayMessage;
        }
        private String GetFullName(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }
        private void ByValueExample(int x)
        {
            x = x * 10;
            lblDisplayMessage.Text += "This number is from Method :"+x.ToString()+"<br>";

        }
        private void ByReferenceExample(ref int x)
        {
            x = x * 10;
            lblDisplayMessage.Text += "This number is from Method byReference :" + x.ToString() + "<br>";

        }
        private void PersonExample()
        {
            Person newPerson = new Person("John", "Miller", "Male");
            Person newPerson1 = new Person();
            lblDisplayMessage.Text = newPerson1.Name;
            //lblDisplayMessage.Text = newPerson1.GetName();
            int i = newPerson.ID;
            newPerson.FirstName = "John";
            newPerson.LastName = "Sanders";
            newPerson.PersonId = 123;
            newPerson.DisplayFirstName = "JS";
            newPerson.Gender = "Male";
            lblDisplayMessage.Text = newPerson.FirstName + "  " + newPerson.LastName + " - " + newPerson.Gender;
        }
        private void InstructorExample()
        {
            Instructor newInstructor = new Instructor();
            newInstructor.PersonId = 1;
            string lastName = newInstructor.LastName = "Simmer";
            string firstName = newInstructor.FirstName;
            lblDisplayMessage.Text = firstName + lastName;
        }
        private void AbstractExample()
        {
            Person newPerson = new Person();
            newPerson.LastName = "Williams";
            newPerson.FirstName = "John";

            lblDisplayMessage.Text = newPerson.Name;
            Label1.Text = newPerson.GetName();

            Location newLocation = new Location();
            Label2.Text = newLocation.GetName();

        }

        private void CollectionExample()
        {
            //Collection Initialiser

            PersonCollection myList = new PersonCollection()
            {
                new Person() { FirstName= "Aby"},
                new Person() { FirstName = "Andy"},
                new Person() { FirstName= "Cathy"},
                new Person() { FirstName = "Debbie" }

            };
/*
            //Object Initialiser Type 2
            PersonCollection myList1 = new PersonCollection();
            myList.Add(new Person() { FirstName = "Cathy" });
            myList.Add(new Person() { FirstName = "Bob" });
            myList.Add(new Person() { FirstName = "Ben" });
*/
            //Object Initialiser Type 1
     /*
            PersonCollection myList2 = new PersonCollection();
            Person person1 = new Person();
            person1.FirstName = "Bob";

            Person person2 = new Person();
            person2.FirstName = "Cathy";

            myList.Add(person1);
            myList.Add(person2);
            */
            StringBuilder sb = new StringBuilder();

            foreach (Person item in myList)
            {
                sb.Append(item.FirstName + " <Br>");
            }

            Label1.Text = sb.ToString();
        }


        private void ExceptionExample()
        {
            String[] myArray = new string[] { "Ant", "Bee", "Cat" };

            try
            {
                lblDisplayMessage.Text = myArray[5];
            }
            catch (IndexOutOfRangeException ex)
            {
                lblDisplayMessage.Text = "Generic Exception: " + ex.Message;
            }
            catch(Exception ex)
            {
                lblDisplayMessage.Text = "There was an exception" + ex.Message;
            }
          
            finally
            {

            }
        }

        private void InterfaceExample()
        {
            Instructor inst = new Instructor()
            {
                FirstName = "Katie",
                LastName= "Duffy",
                HireDate= new DateTime(2006,1,10)
            };
        }
    }
}