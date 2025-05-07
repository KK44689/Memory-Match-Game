using MemoryMatch.Models;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MemoryMatch.Core.Card
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

        private float m_CardLifeTime;

        public int Id { get; set; }
        public int MatchId { get; set; }
        public bool IsAlreadyMatch { get; set; } = false;
        public CardStatus CurrentCardStatus { get; set; } = CardStatus.FaceDown;

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                var status = CurrentCardStatus == CardStatus.FaceDown ? CardStatus.FaceUp : CardStatus.FaceDown;
                FlipCard(status);
            }
        }

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
            var status = CurrentCardStatus == CardStatus.FaceDown ? CardStatus.FaceUp : CardStatus.FaceDown;
            FlipCard(status);
        }
    }
}