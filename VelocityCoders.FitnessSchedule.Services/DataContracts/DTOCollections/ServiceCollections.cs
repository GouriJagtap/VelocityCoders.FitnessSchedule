using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace VelocityCoders.FitnessSchedule.Services.DataContracts
{
    [CollectionDataContract(Name ="EntityDTOCollection")]
    public class EntityDTOCollection : Collection<EntityDTO> { }

    [CollectionDataContract(Name ="EntityTypeDTOCollection")]
    public class EntityTypeDTOCollection : Collection<EntityTypeDTO> { }


    [CollectionDataContract(Name = "GymDTOCollection")]
    public class GymDTOCollection : Collection<GymDTO> { }

    [CollectionDataContract(Name ="FitnessClassDTOCollection")]
    public class FitnessClassDTOCollection : Collection<FitnessClassDTO> { }
}