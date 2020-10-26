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
        private const string TeamFile = "TeamModels.csv";
        private const string TournamentFile = "Tournament.csv";
        private const string MatchupFile = "MatchupModels.csv";
        private const string MatchupEntryFile = "MatchupEntryModels.csv";

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

        public TeamModel Createteam(TeamModel model)
        {
            List<TeamModel> teams = TeamFile.fullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);

            //Find the max ID
            int currentId = 1;
            if (teams.Count > 0)
            {
                currentId = currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            teams.Add(model);

            teams.SaveToTeamFile(TeamFile);

            return model;

        }

        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = TournamentFile
                .fullFilePath()
                .LoadFile()
                .convertTournamentModels(TeamFile, PeopleFile, PrizeFile);

            int currentId = 1;
            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            model.SaveRoundToFile(MatchupFile, MatchupEntryFile);

            tournaments.Add(model);

            tournaments.SaveToTournamentFile(TournamentFile);
        }

        public List<PersonModel> GetPerson_All()
        {
            return PeopleFile.fullFilePath().LoadFile().ConvertToPersonModels();
        }

        public List<TeamModel> GetTeam_All()
        {
            return TeamFile.fullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);
        }
    }
}
