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

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                GenerateCards();
            }
        }

        public void GenerateCards()
        {
            for(int i = 0; i < 6; i++)
            {
                Instantiate(m_CardPrefab, m_CardContainer);
            }
        }
    }
}