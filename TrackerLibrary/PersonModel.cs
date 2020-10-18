using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents one Person
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// The first name of the person
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The last name of the person
        /// </summary>
        public string lastName { get; set; }
        /// <summary>
        /// The primary email address of the person
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// the primary cell phone number of the person
        /// </summary>
        public string CellphoneNumber { get; set; }
    }
}
