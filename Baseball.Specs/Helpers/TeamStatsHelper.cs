using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Baseball.Specs.Helpers
{
    public static class TeamStatsHelper
    {
        public static void Compare(Table table, Lib.Models.TeamStats teamStats)
        {
            if (1 != table.RowCount)
                Assert.Fail("Expected one total team stats row for comparison but got {0}", table.RowCount);

            var row = table.Rows[0];

            if (row.ContainsKey("ABs"))
                Assert.AreEqual(int.Parse(row["ABs"]), teamStats.TotalAtBats);

            if (row.ContainsKey("Runs"))
                Assert.AreEqual(int.Parse(row["Runs"]), teamStats.TotalRuns);

            if (row.ContainsKey("Hits"))
                Assert.AreEqual(int.Parse(row["Hits"]), teamStats.TotalHits);

            if (row.ContainsKey("Doubles"))
                Assert.AreEqual(int.Parse(row["Doubles"]), teamStats.TotalDoubles);

            if (row.ContainsKey("Triples"))
                Assert.AreEqual(int.Parse(row["Triples"]), teamStats.TotalTriples);

            if (row.ContainsKey("HomeRuns"))
                Assert.AreEqual(int.Parse(row["HomeRuns"]), teamStats.TotalHomeRuns);

            if (row.ContainsKey("RBIs"))
                Assert.AreEqual(int.Parse(row["RBIs"]), teamStats.TotalRunsBattedIn);

            if (row.ContainsKey("Walks"))
                Assert.AreEqual(int.Parse(row["Walks"]), teamStats.TotalWalks);

            if (row.ContainsKey("StrikeOuts"))
                Assert.AreEqual(int.Parse(row["StrikeOuts"]), teamStats.TotalStrikeOuts);

            if (row.ContainsKey("Average"))
                Assert.AreEqual(double.Parse(row["Average"]), teamStats.TotalAverage);

            if (row.ContainsKey("OnBasePercentage"))
                Assert.AreEqual(double.Parse(row["OnBasePercentage"]), teamStats.TotalOnBasePercentage);
        }
    }
}