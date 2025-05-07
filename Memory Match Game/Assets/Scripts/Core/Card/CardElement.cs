using MemoryMatch.Models;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
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

        private float m_CardLifeTime = 1;

        public int Id { get; set; }
        public int MatchId { get; set; }
        public bool IsAlreadyMatch { get; set; } = false;
        public CardStatus CurrentCardStatus { get; set; } = CardStatus.FaceDown;
        public UnityAction<int> OnCardFliped { get; set; }

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

        private IEnumerator StartCardCountDown()
        {
            yield return new WaitForSeconds(m_CardLifeTime);
            FlipCard(CardStatus.FaceDown);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(CurrentCardStatus == CardStatus.FaceUp) return;
            else if(CurrentCardStatus == CardStatus.FaceDown)
            {
                FlipCard(CardStatus.FaceUp);
                StartCoroutine(StartCardCountDown());
            }

            OnCardFliped?.Invoke(Id);
        }

        public void SetFrontTexture(Texture2D texture)
        {
            m_FrontTexture = texture;
        }
    }
}