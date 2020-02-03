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

            var replaced = SqlHelper.ReplaceStar<ExampleItem>(sql, null, false);

            Assert.IsNotEmpty(replaced);

            string replacedSql = "SELECT [Id], [Title], [CreatedDate], [OtherItemId] FROM [ExampleItem] ei";

            Assert.AreEqual(replaced, replacedSql);
        }

        [Test]
        public void ReplaceStarT_TableSpecifed()
        {
            var sql = "SELECT * FROM [ExampleItem] ei";

            var replaced = SqlHelper.ReplaceStar<ExampleItem>(sql, "ei", false);

            Assert.IsNotEmpty(replaced);

            string replacedSql = "SELECT ei.[Id], ei.[Title], ei.[CreatedDate], ei.[OtherItemId] FROM [ExampleItem] ei";

            Assert.AreEqual(replaced, replacedSql);
        }

        [Test]
        public void ReplaceFieldsT_NoTableSpecified()
        {
            var sql = "SELECT * FROM [ExampleItem] ei";

            var replaced = SqlHelper.ReplaceStar<ExampleItem>(sql);

            Assert.IsNotEmpty(replaced);

            string replacedSql = "SELECT [Id], [Title] FROM [ExampleItem] ei";

            Assert.AreEqual(replaced, replacedSql);
        }

        [Test]
        public void ReplaceFieldsT_TableSpecifed()
        {
            var sql = "SELECT * FROM [ExampleItem] ei";

            var replaced = SqlHelper.ReplaceStar<ExampleItem>(sql, "ei");

            Assert.IsNotEmpty(replaced);

            string replacedSql = "SELECT ei.[Id], ei.[Title] FROM [ExampleItem] ei";

            Assert.AreEqual(replaced, replacedSql);
        }
    }
}