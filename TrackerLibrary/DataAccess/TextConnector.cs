using System;
using System.Collections.Generic;
using System.Text;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;
using System.Linq;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizeFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        public PersonModel CreatePerson(PersonModel model)
        {
            List<PersonModel> people = PeopleFile.fullFilePath().LoadFile().ConvertToPersonModels();

            int currentId = 1;

            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            people.Add(model);

            people.SaveToPersonFile(PeopleFile);
            return model;
        }

        //TODO - Make the CreatePrize for files
        /// <summary>
        /// Saves a new prize to the textfile.
        /// </summary>
        /// <param name="model">The prize information.</param>
        /// <returns>The prize information, including the uniqe identifier.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            //Load the text file and convert the text to list<prizeModel>
            List<PrizeModel> prizes = PrizeFile.fullFilePath().LoadFile().ConvertToPrizeModels();

            //Find the max ID
            int currentId = 1;
            if (prizes.Count > 0)
            {
                currentId = currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            //add the new record with the new ID (max +1)
            prizes.Add(model);

            //Convert the prizes to list<string>
            //save the list<string> to the text file
            prizes.SaveToPrizeFile(PrizeFile);

            return model;
        }
    }
}
