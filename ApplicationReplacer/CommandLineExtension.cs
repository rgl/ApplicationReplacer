using System.Collections.Generic;
using System.Linq;

namespace ApplicationReplacer
{
    public static class CommandLineExtension
    {
        public static string ToCommandLine(this IEnumerable<string> args)
        {
            return string.Join(" ", args.Select(EscapeArgument));
        }

        public static string EscapeArgument(string arg)
        {
            // Normally, an Windows application (.NET applications too) parses
            // their command line using the CommandLineToArgvW function. Which has
            // some peculiar rules.
            // See http://msdn.microsoft.com/en-us/library/bb776391(VS.85).aspx

            // TODO how about backslashes? there seems to be a weird interaction
            //      between backslahses and double quotes...

            if (arg.Contains('"'))
            {
                return string.Format(
                    "\"{0}\"",
                    // escape single double quotes with another double quote.
                    arg.Replace("\"", "\"\""));
            }
            else if (arg.Contains(' ')) // AND it does NOT contain double quotes! (those were catched in the previous test)
            {
                return string.Format(
                    "\"{0}\"",
                    arg);
            }
            else if (arg == "")
            {
                return "\"\"";
            }
            else
            {
                return arg;
            }
        }
    }
}
