using MemoryMatch.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MemoryMatch.Core.Card
{
    public class CardController : MonoBehaviour, ICardControllable
    {
        [SerializeField]
        private GameObject m_CardPrefab;

        [SerializeField]
        private Transform m_CardContainer;

        [SerializeField]
        private GridLayoutGroup m_LayoutGroup;

        [SerializeField]
        private List<Texture2D> m_CardFrontList;

        private Dictionary<Texture2D, int> m_SetTextureAmountDictionary = new Dictionary<Texture2D, int>();

        private List<ICardElementUI> m_CurrentFlipedIds = new List<ICardElementUI>(2);
        private List<ICardElementUI> m_SpawnedCards = new List<ICardElementUI>();

        private const float CardLifeTime = 1;

        private Coroutine m_FlipCardCoroutine;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                GenerateCards();
            }
        }

        public void GenerateCards()
        {
            InitFrontSprite();

            for(int i = 0; i < 6; i++)
            {
                var card = Instantiate(m_CardPrefab, m_CardContainer);
                var cardElement = card.GetComponent<ICardElementUI>();
                cardElement.Id = i;
                cardElement.OnCardFliped += OnCardFlipedHandler;

                // random texture
                int randomTextureIndex = UnityEngine.Random.Range(0, m_SetTextureAmountDictionary.Count);
                var texture = m_SetTextureAmountDictionary.Select(pair => pair.Key).ToList();
                cardElement.SetFrontTexture(texture[randomTextureIndex]);
                m_SetTextureAmountDictionary[texture[randomTextureIndex]]++;
                if(m_SetTextureAmountDictionary[texture[randomTextureIndex]] >= 2) m_SetTextureAmountDictionary.Remove(texture[randomTextureIndex]);

                m_SpawnedCards.Add(cardElement);
            }

            SetupMatchId();
        }

        private void InitFrontSprite()
        {
            foreach(var texture in m_CardFrontList)
            {
                m_SetTextureAmountDictionary.Add(texture, 0);
            }
        }

        private void SetupMatchId()
        {
            foreach(var card in m_SpawnedCards)
            {
                var spawnedTextureList = m_SpawnedCards.Where(spawnedCard => spawnedCard.Id != card.Id && spawnedCard.FrontTexture == card.FrontTexture).ToList();
              
                card.MatchId = spawnedTextureList[0].Id;
            }
        }

        private IEnumerator StartCardCountDown(ICardElementUI card)
        {
            yield return new WaitForSeconds(CardLifeTime);
            card.FlipCard(CardStatus.FaceDown);
            m_CurrentFlipedIds.Clear();
            m_FlipCardCoroutine = null;
        }

        private void OnCardFlipedHandler(ICardElementUI card)
        {
            Debug.Log($"card flip: {card.Id}");
            if(card.CurrentCardStatus == CardStatus.FaceUp) return;
            else if(card.CurrentCardStatus == CardStatus.FaceDown)
            {
                card.FlipCard(CardStatus.FaceUp);
                m_CurrentFlipedIds.Add(card);

                if(m_CurrentFlipedIds.Count == 2 && m_CurrentFlipedIds[0].MatchId == card.Id)
                {
                    m_CurrentFlipedIds[0].IsAlreadyMatch = true;
                    card.IsAlreadyMatch = true;
                    m_CurrentFlipedIds.Clear();

                    if(m_FlipCardCoroutine != null)
                    {
                        StopCoroutine(m_FlipCardCoroutine);
                        m_FlipCardCoroutine = null;
                    }

                    return;
                }

                m_FlipCardCoroutine = StartCoroutine(StartCardCountDown(card));
            }
        }
    }
}