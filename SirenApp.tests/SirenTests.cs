using Microsoft.Extensions.DependencyInjection;
using SirenApp.Services.Crypto;
using SirenApp.Services.Siren;

namespace SirenApp.tests
{
    public class SirenTests
    {
        private readonly IAmTheTest _iAmTheTest;
        public SirenTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IAmTheTest, AmTheTest>();
            services.AddTransient<ILuhnAlgoService, LuhnAlgoService>();

            var serviceProvider = services.BuildServiceProvider();

            _iAmTheTest = serviceProvider.GetService<IAmTheTest>();
        }

        [Theory]
        [InlineData("732829320")]
        [InlineData("632829321")]
        [InlineData("553279878")]
        [InlineData("217605401")]
        [InlineData("215104217")]
        [InlineData("219733029")]
        public void Check_Siren_Should_Return_True(string sirenToValidate)
        {
            var result = _iAmTheTest.CheckSirenValidity(sirenToValidate);

            Assert.True(result);
        }

        [Theory]
        [InlineData("732729320")]
        [InlineData("622829321")]
        [InlineData("553279978")]
        [InlineData("217705401")]
        [InlineData("225104217")]
        [InlineData("219733009")]
        public void Check_Siren_Should_Return_False(string sirenToValidate)
        {
            var result = _iAmTheTest.CheckSirenValidity(sirenToValidate);

            Assert.False(result);
        }

        [Theory]
        [InlineData("")]
        public void Check_Siren_Should_Return_False_When_Entry_Is_Empty(string sirenToValidate)
        {
            var result = _iAmTheTest.CheckSirenValidity(sirenToValidate);

            Assert.False(result);
        }

        [Theory]
        [InlineData("7328293202")]
        [InlineData("73282932")]
        public void Check_Siren_Should_Return_False_When_Entry_Length_Not_Equals_Nine(string sirenToValidate)
        {
            var result = _iAmTheTest.CheckSirenValidity(sirenToValidate);

            Assert.False(result);
        }

        [Theory]
        [InlineData("732A29320")]
        [InlineData("5532798B8")]
        public void Check_Siren_Should_Return_False_When_Entry_Not_Full_Digits(string sirenToValidate)
        {
            var result = _iAmTheTest.CheckSirenValidity(sirenToValidate);

            Assert.False(result);
        }

        [Theory]
        [InlineData("73282932", "732829320")]
        [InlineData("63282932", "632829321")]
        [InlineData("55327987", "553279878")]
        [InlineData("21760540", "217605401")]
        [InlineData("21510421", "215104217")]
        [InlineData("21973302", "219733029")]
        public void Compute_Full_Siren_Should_Be_Valid(string sirenWithoutControlNumber, string expectedSirenComputed)
        {
            var result = _iAmTheTest.ComputeFullSiren(sirenWithoutControlNumber);

            Assert.Equal(expectedSirenComputed, result);
        }
    }
}
