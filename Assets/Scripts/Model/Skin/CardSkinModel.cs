using System;
using Model.Type;
using UnityEngine;

namespace Model.Skin
{
    [Serializable]
    public class CardSkinModel : ScriptableObject
    {
        [SerializeField] private Sprite cardHidden;
        [SerializeField] private Sprite[] cardFaceHearts;
        [SerializeField] private Sprite[] cardFaceDiamonds;
        [SerializeField] private Sprite[] cardFaceClubs;
        [SerializeField] private Sprite[] cardFaceSpades;
        [SerializeField] private Sprite cardBack;

        public Sprite GetFace(CardType cardType)
        {
            int cardValue = (int)cardType.rank;
            if (cardValue == 0) return cardHidden;
            cardValue--;

            switch (cardType.suit)
            {
                case Suits.Hearts:
                    return cardFaceHearts[cardValue];
                case Suits.Diamonds:
                    return cardFaceDiamonds[cardValue];
                case Suits.Clubs:
                    return cardFaceClubs[cardValue];
                case Suits.Spades:
                    return cardFaceSpades[cardValue];
                default:
                    return null;
            }
        }

        public Sprite GetFace(int rank, int suit)
        {
            if (rank == 0) return cardHidden;
            rank--;

            switch (suit)
            {
                case 0:
                    return cardFaceHearts[rank];
                case 1:
                    return cardFaceDiamonds[rank];
                case 2:
                    return cardFaceClubs[rank];
                case 3:
                    return cardFaceSpades[rank];
                default:
                    return null;
            }
        }

        public Sprite GetBack()
        {
            return cardBack;
        }
    }
}