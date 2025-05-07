using MemoryMatch.Models;
using UnityEngine;

namespace MemoryMatch.Core.Card
{
    public class CardElement : MonoBehaviour, ICardElementUI
    {
        [SerializeField]
        private CardStatus cardStatus;

        [SerializeField]
        private Material m_FrontMaterial;

        [SerializeField]
        private Material m_BackMaterial;

        private float m_CardLifeTime;
        private Renderer m_Renderer;

        public int Id { get; set; }
        public int MatchId { get; set; }
        public bool IsAlreadyMatch { get; set; } = false;
        public CardStatus CurrentCardStatus { get; set; } = CardStatus.FaceDown;

        private void Awake()
        {
            m_Renderer = GetComponent<Renderer>();
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                FlipCard(CurrentCardStatus);
            }
        }

        public void FlipCard(CardStatus status)
        {
            CurrentCardStatus = status;

            switch(status)
            {
                case CardStatus.FaceDown:
                    m_Renderer.material = m_BackMaterial;
                    break;
                case CardStatus.FaceUp:
                    m_Renderer.material = m_FrontMaterial;
                    break;
            }
        }
    }
}