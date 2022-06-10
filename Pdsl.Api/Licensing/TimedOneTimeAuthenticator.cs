﻿using System.Security.Cryptography;
using System.Text;
using TwoStepsAuthenticator;

namespace Pdsl.Api.Licensing
{
    public class TimedOneTimeAuthenticator : ITimedOneTimeAuthenticator
    {
        public CryptoCode GenerateCode()
        {
            var secret = "pqrstuvwxyzABCDE"; // GenerateSecret();

            var authenticator = new TimeAuthenticator();
            var code = authenticator.GetCode(secret);

            return new CryptoCode(new Secret(secret), new Code(code));
        }

        private static string GenerateSecret()
        {
            var characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

            var cryptoSecretGenerator = RandomNumberGenerator.Create();
            var bytes = new byte[64];
            cryptoSecretGenerator.GetBytes(bytes);

            var secretLength = 16;
            var secret = new StringBuilder(secretLength);
            for (int i = 0; i < secretLength; i++)
            {
                var randomNumber = BitConverter.ToUInt32(bytes, i * 4);
                var index = randomNumber % characters.Length;

                secret.Append(characters[index]);
            }

            return secret.ToString();
        }

        public bool UserCodeIsValid(Visitor user, CryptoCode code)
        {
            if(user.Secret.Text is null)
            {
                return false;
            }

            if(code.Code.Text is null)
            {
                return false;
            }

            var authenticator = new TimeAuthenticator();
            return authenticator.CheckCode($"{user.Secret}", $"{code.Code}", user);
        }
    }
}
