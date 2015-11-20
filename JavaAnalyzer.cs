using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication3
{
    public static class JavaAnalyzer
    { 
        public static string DeleteTheComments(string JavaCode)
        {
            Regex Comment = new Regex(@"//(.*?)");
            JavaCode = Comment.Replace(JavaCode, "");
            Regex MultiComment = new Regex(@"/(\*)(.*?)(\*)/", RegexOptions.Singleline);
            JavaCode = MultiComment.Replace(JavaCode, "");
            return JavaCode;
        }

        public static string DeleteTheStrings(string JavaCode)
        {
            Regex String = new Regex(@"""(.*?)""", RegexOptions.Singleline);
            JavaCode = String.Replace(JavaCode, "");
            return JavaCode;
        }

        private const int TypeCount = 9;
        private static readonly string[] JavaTypes = { "byte", "short", "int", "long", "float", "double", "boolean", "char", "String"};
        public static List<string> GetVariables(string JavaCode)
        {
            List<string> Result = new List<string>();
            for (int j = 0; j < TypeCount; j++)
            {
                Regex RegularExpression = new Regex(@"\b" + JavaTypes[j] + @"\b" + @"\s+\w+[^()]*;");
                Match Match = RegularExpression.Match(JavaCode);
                while (Match.Success)
                {
                    string Declaration = Match.Value;
                    int i = 0;
                    while (Declaration[i] != ' ')
                    {
                        i++;
                    }
                    while (Declaration[i] != ';')
                    {
                        i++;
                        string Variable = "";
                        while (Declaration[i] == ' ')
                        {
                            i++;
                        }
                        while ((Declaration[i] != ' ') && (Declaration[i] != '=') && (Declaration[i] != ';') && (Declaration[i] != ','))
                        {
                            Variable = Variable + Declaration[i];
                            i++;
                        }
                        Result.Add(Variable);
                        while ((Declaration[i] != ',') && (Declaration[i] != ';'))
                        {
                            i++;
                        }
                    }
                    Match = Match.NextMatch();
                }
            }
            return Result;
        }

        public struct VariableInfo
        {
            public string Identifier;
            public bool IsData, IsModified, IsSteward, IsParasitic;
        }

        private const int OutputMethodsCount = 7;
        private static readonly string[] OutputMethods = { "print", "println", "printf", "write", "writeDouble", "writeBoolean", "writeInt" };
        private const int InputMethodsCount = 5;
        private static readonly string[] InputMethods = { "read", "readDouble", "readBoolean", "readInt", "nextInt" };
        private static bool IsDataVariable(string Variable, string JavaCode)
        {
            for (int i = 0; i < OutputMethodsCount; i++)
            {
                Regex RegularExpression = new Regex(OutputMethods[i] + @"\s*\([^)]*" + Variable + @"[^)]*\)");
                Match Match = RegularExpression.Match(JavaCode);
                if (Match.Success)
                {
                    return true;
                }
            }
            for (int i = 0; i < InputMethodsCount; i++)
            {
                Regex RegularExpression = new Regex(Variable + @"\s*=[^;]*" + InputMethods[i]);
                Match Match = RegularExpression.Match(JavaCode);
                if (Match.Success)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsStewardVariable(string Variable, string JavaCode)
        {
            Regex RegularExpression = new Regex(@"((for)|(while)|(if))\s*\(\s*" + Variable);
            Match Match = RegularExpression.Match(JavaCode);
            if (Match.Success)
            {
                return true;
            }
            return false;
        }

        private static bool IsModifiedVariable(string Variable, string JavaCode)
        {
            Regex RegularExpression = new Regex(/*@"[;{]\s*" +*/ @"\s*" + Variable + @"\s*=");
            Match Match = RegularExpression.Match(JavaCode);
            if (Match.Success)
            {
                return true;
            }
            return false;
        }

        private static VariableInfo GetVariableInfo(string Variable, string JavaCode)
        {
            VariableInfo Result = new VariableInfo();
            Result.Identifier = Variable;
            Result.IsData = IsDataVariable(Variable, JavaCode);
            Result.IsSteward = IsStewardVariable(Variable, JavaCode);
            Result.IsModified = IsModifiedVariable(Variable, JavaCode);
            if (!(Result.IsData || Result.IsModified || Result.IsSteward))
                Result.IsParasitic = true;
            else
                Result.IsParasitic = false;
            return Result;
        }

        public static List<VariableInfo> GetVariablesInfo(List<string> Variables, string JavaCode)
        {
            List<VariableInfo> Result = new List<VariableInfo>();
            for (int i = 0; i < Variables.Count; i++)
            {
                Result.Add(GetVariableInfo(Variables[i], JavaCode));
            }
            return Result;
        }
    }
}
