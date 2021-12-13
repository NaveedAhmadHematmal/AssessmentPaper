using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace AssessmentPaper.WebApi.Models;

public class QuestionModel{
    public ObjectId _id { get; set; }
    [Required()]
    [MinLength(10, ErrorMessage = "The question must be at least 10 characters.")]
    public string Question { get; set; }
    [Required]
    [MinLength(3, ErrorMessage = "There must be at least three answer options.")]
    public Option[] AnswerOptions { get; set; }
    [Required]
    [MaxLength(1, ErrorMessage = "The answer must be a character pointing to one option in the AnswerOptions.")]
    public string Answer { get; set; }
    public string[] Tags { get; set; }
    public string Rating { get; set; }
    public string WrittenLanguage { get; set; }
}
public class Option{
    [Required]
    [MaxLength(1, ErrorMessage = "The key to the option must be a character.")]
    public string Key { get; set; }
    [Required]
    public string Value { get; set; }
}