using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Tests.Helper
{
    internal class HttpHelper
    {
        internal static class Urls
        {
            private readonly static string baseURL = $"api/";
            public readonly static string AccountsURL = $"{baseURL}Accounts/";
            public readonly static string ExercisesURL = $"{baseURL}Exercises/";
            public readonly static string ExerciseTemplatesURL = $"{baseURL}ExerciseTemplats/";
            public readonly static string MacrosURL = $"{baseURL}Macros/";
            public readonly static string MediasURL = $"{baseURL}Medias/";
            public readonly static string PlansURL = $"{baseURL}Plans/";
            public readonly static string SessionsURL = $"{baseURL}Sessions/";
        }
    }
}
