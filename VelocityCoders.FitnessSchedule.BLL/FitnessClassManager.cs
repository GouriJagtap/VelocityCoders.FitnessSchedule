using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;
using VelocityCoders.FitnessSchedule.DAL;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.BLL
{
   public static class FitnessClassManager
    {
        #region GET SINGLE ITEM
        public static FitnessClass GetItem(int fitnessClassId)
        {
            return FitnessClassDAL.GetItem(fitnessClassId);
        }
        #endregion

        #region GET COLLECTION
        public static FitnessClassCollection GetCollection()
        {
            return FitnessClassDAL.GetCollection();
        }
        #endregion

        #region INSERT UPDATE

        public static int Save(FitnessClass fitnessClassToSave)
        {
            int fitnessClassId = SaveFitnessClass(fitnessClassToSave);
            fitnessClassToSave.FitnessClassId = fitnessClassId;

            return FitnessClassDAL.Save(fitnessClassToSave);


        }

        #endregion

        #region DELETE

        public static bool Delete(int fitnessClassId)
        {
            if (fitnessClassId > 0)
                return FitnessClassDAL.Delete(fitnessClassId);
            else
                throw new BLLException("Delete failed. FitnessClass ID is Invalid: " + fitnessClassId.ToString());
        }
        #endregion

        #region HELPER METHODS

        public static int SaveFitnessClass(FitnessClass fitnessClassToSave)
        {
            FitnessClass tempClass = new FitnessClass();

            tempClass.FitnessClassId = fitnessClassToSave.FitnessClassId;
            tempClass.FitnessClassName = fitnessClassToSave.FitnessClassName;

            return FitnessClassManager.Save(tempClass);
        }
        #endregion

    }
}
