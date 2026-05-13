using FamousQuoteQuiz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamousQuoteQuiz.Persistence.Configurations;

public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
{
    public void Configure(EntityTypeBuilder<Quote> builder)
    {
        builder.HasData(
            new Quote
            {
                Id = 1,
                Text = "To be, or not to be, that is the question.",
                Author = "William Shakespeare"
            },
            new Quote
            {
                Id = 2,
                Text = "I think, therefore I am.",
                Author = "René Descartes"
            },
            new Quote
            {
                Id = 3,
                Text = "The only thing we have to fear is fear itself.",
                Author = "Franklin D. Roosevelt"
            },
            new Quote
            {
                Id = 4,
                Text = "That's one small step for man, one giant leap for mankind.",
                Author = "Neil Armstrong"
            }
        );
    }
}
