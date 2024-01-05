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
            public readonly static string ExerciseURL = $"{baseURL}exercise/";
            public readonly static string ExerciseTemplateURL = $"{baseURL}exerciseTemplate/";
            public readonly static string WorkoutURL = $"{baseURL}workout/";
            public readonly static string MacroURL = $"{baseURL}macro/";
            public readonly static string AccountURL = $"{baseURL}account/";
        }
    }
}
