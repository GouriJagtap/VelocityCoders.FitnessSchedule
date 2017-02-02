using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Models.Collections;
using VelocityCoders.FitnessSchedule.DAL;
using VelocityCoders.FitnessSchedule.Models;


namespace VelocityCoders.FitnessSchedule.WebForms.Admin
{
    public partial class EntityTypeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindEntityTypeList();
        }
        #region DataBind

        private void BindEntityTypeList()
        {
           EntityTypeCollection entityTypeList = new EntityTypeCollection();
            entityTypeList = EntityTypeDAL.GetCollection();
            rptEntityTypeList.DataSource = entityTypeList;
            rptEntityTypeList.DataBind();
        }
        #endregion
    }
}