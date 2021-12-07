namespace AssessmentPaper.WebApi;

public class QuestionModel{
    public string Question { get; set; }
    public Option[] AnswerOptions { get; set; }
    public string Answer { get; set; }
    public string[] Tags { get; set; }
    public string Rating { get; set; }
    public string WrittenLanguage { get; set; }
}
public class Option{
    public string Key { get; set; }
    public string Value { get; set; }
}