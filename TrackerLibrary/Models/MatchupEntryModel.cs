using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents one team in a Matchup
    /// </summary>
    public class MatchupEntryModel
    {
        /// <summary>
        /// Represent one team in the Matchup.
        /// </summary>
        public TeamModel TeamCompeting { get; set; }
        /// <summary>
        /// Represents the score for this particalar team.
        /// </summary>
        public double Score { get; set; } 
        /// <summary>
        /// Represents the matchup that this team 
        /// came from as the winner.
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }

    }
}
