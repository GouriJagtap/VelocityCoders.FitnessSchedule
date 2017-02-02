using Jagtap.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.DAL;
using VelocityCoders.FitnessSchedule.Models;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin
{
    public partial class EntityTypeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindEntityType();
        }
        #region Bind 

        private void BindEntityType()
        {
            int entityTypeId = Request.QueryString["EntityTypeId"].ToInt();

            if (entityTypeId > 0)
            {

                EntityType entityTypeLookup = EntityTypeDAL.GetItem(entityTypeId);

                if (entityTypeLookup != null)
                {

                    lblEntityTypeId.Text = entityTypeLookup.EntityTypeId.ToString();
                    lblEntityId.Text = entityTypeLookup.EntityId.ToString();
                    lblEntityTypeName.Text = entityTypeLookup.EntityTypeName.ToString();
                   }
                else
                    lblMessage.Text = "Instructor could not be found.";
            }
            else
                lblMessage.Text = "Invalid Id. Instructor record could not be found.";
        }
        #endregion
    }
}