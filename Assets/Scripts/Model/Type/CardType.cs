using System;
using TriInspector;

namespace Model.Type
{
    [Serializable]
    [DeclareHorizontalGroup("CardType")]
    public class CardType
    {
        [Group("CardType")] public Ranks rank;
        [Group("CardType")] public Suits suit;
    }
}