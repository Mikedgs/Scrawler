using System;
using System.Collections.Generic;
using System.Linq;
using Mindscape.LightSpeed.Validation;
using Moq;
using NUnit.Framework;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace ScrawlerTests.Plumbing
{
    [TestFixture]
    public class CanWeBreakTheRepository
    {
        [Test]
        [Ignore]
        public void Disposable_mularkey()
        {
            // const string connectionString = @"server=.\sqlexpress;Database=scrawler;Trusted_Connection=True;";
            const string connectionString =
                @"Server=tcp:bc2wsegi5e.database.windows.net,1433;Database=ScrawlerDB;User ID=devacademy@bc2wsegi5e;Password=15WalterStreet;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";

            var repos = new List<Repository<Chatroom>>();

            // Arrange
            for (var i = 0; i < 181; i++)
            {
                var repo = new Repository<Chatroom>(Mock.Of<IConfiguration>(x => x.ConnectionString == connectionString));
                repos.Add(repo);
                var junk = repo.GetAll().First();
                Console.WriteLine(junk.FirebaseId);
            }

            // Act

            // Assert
            Assert.That(repos.Count, Is.EqualTo(100));

        }
    }
}