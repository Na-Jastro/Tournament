﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents one Person
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        ///The unique identifier for the person.
        /// </summary>
        public int Id { get; set; }
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

        /// <summary>
        /// Readonly for fullName.
        /// </summary>
        public string FullName
        {
            get { return $"{FirstName} {lastName}"; }
        }
    }
}
