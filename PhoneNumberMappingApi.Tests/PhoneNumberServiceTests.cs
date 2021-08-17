using PhoneNumberMappingApi.Infrastructure.Implementation.Services;
using System;
using Xunit;

namespace PhoneNumberMappingApi.Tests
{
    public class PhoneNumberServiceTests
    {
        [Theory]
        [InlineData(null, "0499 111-11-11", "+414991111111")]
        [InlineData(null, "079 257 3115", "+41792573115")]
        [InlineData(null, "(0)79 / 257-31-15", "+41792573115")]
        [InlineData("+7", "0499 111-11-11", "+74991111111")]
        [InlineData("+7", "079 257 3115", "+7792573115")]
        [InlineData("+7", "(0)79 / 257-31-15", "+7792573115")]

        public void ValidPhoneNumberInput(string prefix, string phoneNumber, string expected)
        {
            var phoneNumberService = new PhoneNumberService();

            var result = phoneNumberService.Map(prefix, phoneNumber);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(null, "qweqweqwe")]
        [InlineData(null, "123")]
        [InlineData(null, "")]
        [InlineData(null, "+410991111111")]
        [InlineData(null, "+0000")]
        [InlineData("+7", "qweqweqwe")]
        [InlineData("+7", "123")]
        [InlineData("+7", "")]
        [InlineData("+7", "+0000")]

        public void InValidPhoneNumberInput(string prefix, string phoneNumber)
        {
            var phoneNumberService = new PhoneNumberService();

            Assert.Throws<Exception>(() => phoneNumberService.Map(prefix, phoneNumber));
        }
    }
}
