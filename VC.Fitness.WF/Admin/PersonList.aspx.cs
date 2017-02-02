using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.DAL;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;
using Jagtap.Common.Extensions;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin
{
    public partial class PersonList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindPersonList();
          
        }
        #region DataBind

        private void BindPersonList()
        {
            PersonCollection personList = new PersonCollection();
            personList = PersonDAL.GetCollection();
            rptPersonList.DataSource = personList;
            rptPersonList.DataBind();
        }
        #endregion

       
    }

}