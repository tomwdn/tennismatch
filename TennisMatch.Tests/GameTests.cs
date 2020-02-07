using AutoFixture;
using Moq;
using NUnit.Framework;

namespace TennisMatch.Tests
{
    public class SetTests : TestBase
    {
        [SetUp]
        public void SetUp()
        {
            Init();
            _gameFactory = Fixture.Freeze<Mock<IGameFactory>>();
            _set = Fixture.Create<Set>();
        }

        private Set _set;
        private Mock<IGameFactory> _gameFactory;

        [TestCase(1, 0)]
        [TestCase(0, 1)]
        public void Play_Should_Return_2_Sets_When_Either_Player_Wins_Both_Games(int player1Games, int player2Games)
        {
            var set = new Mock<ISet>();
            set.Setup(x => x.Player1Games).Returns(player1Games);
            set.Setup(x => x.Player2Games).Returns(player2Games);
            _gameFactory.Setup(x => x.Create()).Returns(set.Object);

            var result = _set.Start();

            result.Count.Should().Be(2);
        }

        //[Test]
        //public void Play_Should_Return_3_Sets_When_Both_Players_Wins_At_Least_One_Game()
        //{
        //    var set1 = new Mock<ISet>();
        //    var set2 = new Mock<ISet>();
        //    set1.SetupGet(x => x.Player1Games).Returns(1);
        //    set2.SetupGet(x => x.Player2Games).Returns(1);

        //    _setFactory.SetupSequence(x => x.Create()).Returns(set1.Object).Returns(set2.Object).Returns(set1.Object);

        //    var result = _set.Play();

        //    result.Count.Should().Be(3);
        //}
    }
}