using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Constants.Apis
{
    public static class Expedia
    {
        public static class Test
        {
            public const string Username = "EQCtest12933870";
            public const string Password = "ew67nk33";

            public static class AuthorizationHeader
            {
                public const string Key = "Authorization";
                public static string Value = $"Basic {$"{Username}:{Password}".Base64Encode()}";
            }
        }
    }
}
