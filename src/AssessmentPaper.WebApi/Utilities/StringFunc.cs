using System.Text.RegularExpressions;

namespace AssessmentPaper.WebApi.Utilities;

public static class StringFunc{
    public static string[] SplitCommanSeperatedStringIntoObjectArray(this string input){
        string[] a = input.Replace(" ", "").Split(",");
        return a;
    }

    public static string[] SplitSpaceSeperatedStringIntoObjectArray(this string input){
        string[] a = input.Split(" ");
        return a;
    }

    public static string RemoveExceptLetters(this string input){
        
        // remove numbers and punctuations
        // hypen - and dot . are allowed characters

        for(int i = 0; i < input.Length; i++)
        {
            if(!(input[i] >= 65 && input[i] <= 90 || input[i] >= 97 && input[i] <= 122 || input[i] == 32 || input[i] == 45 || input[i] == 46))
            {
                input = input.Replace(input[i].ToString(), "");
            }
        }

        // remove multiple spaces
        input = Regex.Replace(input, @"\s+", " ");
        
        return input;
    }
}