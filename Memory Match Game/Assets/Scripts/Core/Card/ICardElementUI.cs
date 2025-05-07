namespace MemoryMatch.Models
{
    public interface ICardElementUI
    {
        int Id { get; set; }
        int MatchId { get; set; }
        bool IsAlreadyMatch { get; set; }
        CardStatus CurrentCardStatus { get; set; }
        
        void FlipCard(CardStatus status);
    }
}