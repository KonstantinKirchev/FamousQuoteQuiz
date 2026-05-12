namespace FamousQuoteQuiz.Application.Features.Quote.Queries.GetQuotes
{
    public class QuoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public bool IsDeleted { get; set; }
    }
}
