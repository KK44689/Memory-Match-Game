using MemoryMatch.Core.Card;
using MemoryMatch.Models;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MemoryMatch.UI
{
    public class CardElement : MonoBehaviour, ICardElementUI, IPointerDownHandler
    {
        [SerializeField]
        private CardStatus cardStatus;

        [SerializeField]
        private Texture2D m_FrontTexture;

        [SerializeField]
        private Texture2D m_BackTexture;

        [SerializeField]
        private RawImage m_RawImage;

        public int Id { get; set; }
        public int MatchId { get; set; }
        public bool IsAlreadyMatch { get; set; } = false;
        public CardStatus CurrentCardStatus { get; set; } = CardStatus.FaceDown;
        public UnityAction<ICardElementUI> OnCardFliped { get; set; }
        public Texture2D FrontTexture { get => m_FrontTexture; }

        public void FlipCard(CardStatus status)
        {
            CurrentCardStatus = status;

            switch(status)
            {
                case CardStatus.FaceDown:
                    m_RawImage.texture = m_BackTexture;
                    break;
                case CardStatus.FaceUp:
                    m_RawImage.texture = m_FrontTexture;
                    break;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(IsAlreadyMatch) return;
            OnCardFliped?.Invoke(this);
        }

        public void SetFrontTexture(Texture2D texture)
        {
            m_FrontTexture = texture;
        }
    }
}