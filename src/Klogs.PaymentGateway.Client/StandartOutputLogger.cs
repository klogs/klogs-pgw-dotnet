using System;
using System.Text.RegularExpressions;

namespace Klogs.PaymentGateway.Client
{
    public interface ILogger
    {
        void LogDebug(string text, params object[] obj);

        void LogError(string text, params object[] obj);

        void LogError(Exception ex, string text, params object[] obj);

        void LogInformation(string text, params object[] obj);
    }

    internal class StandartOutputLogger : ILogger
    {
        private static string render(string template, params object[] obj)
        {
            int i = 0;

            return Regex.Replace(template, @"\{([^}]+)\}", m =>
            {
                return obj[i++].ToString();
            });
        }


        public void LogDebug(string text, params object[] obj)
        {
            Console.Out.WriteLine(render(text, obj));
        }

        public void LogError(string text, params object[] obj)
        {
            Console.Error.WriteLine(render(text, obj));
        }

        public void LogError(Exception ex, string text, params object[] obj)
        {
            Console.Error.WriteLine("{0}. {1}", render(text, obj), ex.ToString());
        }

        public void LogInformation(string text, params object[] obj)
        {
            Console.Out.WriteLine(render(text, obj));
        }
    }
}
