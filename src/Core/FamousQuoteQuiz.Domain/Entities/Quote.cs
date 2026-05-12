
using FamousQuoteQuiz.Domain.Common;

namespace FamousQuoteQuiz.Domain.Entities;

public class Quote : BaseEntity
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Author { get; set; }
    public bool IsDeleted { get; set; }
}
