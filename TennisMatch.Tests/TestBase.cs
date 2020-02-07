using AutoFixture;
using AutoFixture.AutoMoq;
using NUnit.Framework;

namespace TennisMatch.Tests
{
    [TestFixture]
    public class TestBase
    {
        protected IFixture Fixture;

        protected void Init()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
        }
    }
}