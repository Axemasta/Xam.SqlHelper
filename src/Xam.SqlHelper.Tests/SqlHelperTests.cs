using NUnit.Framework;
using Xam.SqlHelper.Sample.Models;

namespace Xam.SqlHelper.Tests
{
    [TestFixture]
    public class SqlHelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReplaceStarT_NoTableSpecified()
        {
            var sql = "SELECT * FROM [ExampleItem] ei";

            var replaced = SqlHelper.ReplaceStar<ExampleItem>(sql);

            Assert.IsNotEmpty(replaced);

            string replacedSql = "SELECT [Id], [Title], [CreatedDate], [OtherItemId] FROM [ExampleItem] ei";

            Assert.AreEqual(replaced, replacedSql);
        }

        [Test]
        public void ReplaceStarT_TableSpecifed()
        {
            var sql = "SELECT * FROM [ExampleItem] ei";

            var replaced = SqlHelper.ReplaceStar<ExampleItem>(sql, "ei");

            Assert.IsNotEmpty(replaced);

            string replacedSql = "SELECT ei.[Id], ei.[Title], ei.[CreatedDate], ei.[OtherItemId] FROM [ExampleItem] ei";

            Assert.AreEqual(replaced, replacedSql);
        }

        [Test]
        public void ReplaceFieldsT_NoTableSpecified()
        {
            var sql = "SELECT * FROM [ExampleItem] ei";

            var replaced = SqlHelper.ReplaceStar<ExampleItem>(sql, null, true);

            Assert.IsNotEmpty(replaced);

            string replacedSql = "SELECT [Title], [CreatedDate] FROM [ExampleItem] ei";

            Assert.AreEqual(replaced, replacedSql);
        }

        [Test]
        public void ReplaceFieldsT_TableSpecifed()
        {
            var sql = "SELECT * FROM [ExampleItem] ei";

            var replaced = SqlHelper.ReplaceStar<ExampleItem>(sql, "ei", true);

            Assert.IsNotEmpty(replaced);

            string replacedSql = "SELECT ei.[Title], ei.[CreatedDate] FROM [ExampleItem] ei";

            Assert.AreEqual(replaced, replacedSql);
        }

        //[Test]
        //public void ReplaceStarFields_NoTableSpecified()
        //{
        //    var sql = "SELECT * FROM [tracks] tr";

        //    var replaced = SqlHelper.ReplaceStar(sql, null, nameof(Track.TrackId), nameof(Track.Name), nameof(Track.Megabytes));

        //    Assert.IsNotEmpty(replaced);

        //    string replacedSql = "SELECT [TrackId], [Name], [Megabytes] FROM [tracks] tr";

        //    Assert.AreEqual(replaced, replacedSql);
        //}

        //[Test]
        //public void ReplaceStarFields_TableSpecified()
        //{
        //    var sql = "SELECT * FROM [tracks] tr";

        //    var replaced = SqlHelper.ReplaceStar(sql, "tr", nameof(Track.TrackId), nameof(Track.Name), nameof(Track.Megabytes));

        //    Assert.IsNotEmpty(replaced);

        //    string replacedSql = "SELECT tr.[TrackId], tr.[Name], tr.[Megabytes] FROM [tracks] tr";

        //    Assert.AreEqual(replaced, replacedSql);
        //}
    }
}