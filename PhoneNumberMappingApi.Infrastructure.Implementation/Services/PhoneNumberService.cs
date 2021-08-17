using PhoneNumberMappingApi.Infrastructure.Interfaces.Services;
using System;
using System.Linq;

namespace PhoneNumberMappingApi.Infrastructure.Implementation.Services
{
    internal class PhoneNumberService : IPhoneNumberService
    {
        private readonly string defaultPrefix = "+41";

        //We could use StringBuilder here, but I'm not a big fan of micro-optimization
        public string Map(string prefix, string phoneNumber)
        {
            if (string.IsNullOrEmpty(prefix))
                prefix = defaultPrefix;

            if(phoneNumber.StartsWith(prefix))
            {
                phoneNumber = phoneNumber[prefix.Length..];

                if(phoneNumber.StartsWith("0"))
                    throw new Exception();
            }

            var onlyNumbersString = new string(phoneNumber.Where(char.IsDigit).ToArray());

            if(onlyNumbersString.Length == 0)
                throw new Exception();

            if (onlyNumbersString[0] == '0')
                onlyNumbersString = onlyNumbersString[1..];

            if (onlyNumbersString.StartsWith("0"))
                throw new Exception();

            var resultString = $"{prefix}{onlyNumbersString}";

            if (resultString.Length < 11)
                throw new Exception();

            return resultString;
        }
    }
}
