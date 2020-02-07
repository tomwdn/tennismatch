using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace TennisMatch.Tests
{
    [TestFixture]
    public class MatchTests
    {
        [SetUp]
        public void SetUp()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            _setFactory = fixture.Freeze<Mock<ISetFactory>>();
            _match = fixture.Create<Match>();
        }

        private Match _match;
        private Mock<ISetFactory> _setFactory;

        [TestCase(1, 0)]
        [TestCase(0, 1)]
        public void Play_Should_Return_2_Sets_When_Either_Player_Wins_Both_Games(int player1Games, int player2Games)
        {
            var set = new Mock<ISet>();
            set.Setup(x => x.Player1Games).Returns(player1Games);
            set.Setup(x => x.Player2Games).Returns(player2Games);
            _setFactory.Setup(x => x.Create()).Returns(set.Object);

            var result = _match.Play();

            result.Count.Should().Be(2);
        }

        [Test]
        public void Play_Should_Return_3_Sets_When_Both_Players_Wins_At_Least_One_Game()
        {
            var set1 = new Mock<ISet>();
            var set2 = new Mock<ISet>();
            set1.SetupGet(x => x.Player1Games).Returns(1);
            set2.SetupGet(x => x.Player2Games).Returns(1);

            _setFactory.SetupSequence(x => x.Create()).Returns(set1.Object).Returns(set2.Object).Returns(set1.Object);

            var result = _match.Play();

            result.Count.Should().Be(3);
        }
    }
}