namespace AssessmentPaper.WebApi.Utilities;

public static class StringFunc{
    public static string[] SplitCommanSeperatedStringIntoObjectArray(this string input){
        string[] a = input.Replace(" ", "").Split(",");
        return a;
    }
}