using Controller.ScriptableObjects.Skins;
using Model.Type;
using TriInspector;
using UnityEngine;

namespace Model.MonoBehaviours.Cards
{
    public class CardModel : MonoBehaviour
    {
        [SerializeField] [OnValueChanged(nameof(CardTypeChanged))]
        protected CardType cardType;

        [SerializeField] protected MeshRenderer meshRenderer;
        [SerializeField] protected CardSkinController cardSkinController;
        public void CardTypeChanged()
        {
            meshRenderer.material.mainTexture = cardSkinController.GetFace(cardType).texture;
        }
    }
}