namespace VelocityCoders.FitnessSchedule.WebForms
{
    /// <summary>
    /// Represents the Instructor subheader navigation when navigating within the Instructor
    /// </summary>
    public enum InstructorNavigation
    {
        /// <summary>
        /// Default to none value
        /// </summary>
        None = 0,

        /// <summary>
        /// Page contains a list of all the Instructors
        /// </summary>
        InstructorList = 10,
        /// <summary>
        /// This Page contains form for basic Instructor information
        /// </summary>
        InstructorForm= 20,

        /// <summary>
        /// This page contains Instructor contact info
        /// </summary>
        ContactInfo = 30,

        /// <summary>
        /// This Page contains the association between Instructor and FitnessClass
        /// </summary>
        FitnessClass=40,
        /// <summary>
        /// This Page contains the association between Instructor and Location
        /// </summary>
        Locations=50




    }
}