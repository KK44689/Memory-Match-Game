using UnityEngine;
using UnityEngine.Events;

namespace MemoryMatch.Models
{
    public interface ICardElementUI
    {
        int Id { get; set; }
        int MatchId { get; set; }
        bool IsAlreadyMatch { get; set; }
        Texture2D FrontTexture { get; }
        CardStatus CurrentCardStatus { get; set; }

        UnityAction<ICardElementUI> OnCardFliped { get; set; }

        void FlipCard(CardStatus status);
        void SetFrontTexture(Texture2D texture);
    }
}