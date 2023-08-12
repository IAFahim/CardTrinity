using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class CardSpawnerForAnimation : MonoBehaviour
    {
        public Animator cardAnimator; // Animator for the card animation
        public GameObject cardPrefab; // Prefab of the card to spawn
        public int numberOfCardsToSpawn = 52; // Number of cards to spawn
        public List<GameObject> spawnedCards; // List of spawned cards
        public void SpawnCardsWithAnimation()
        {
            Transform cardAnimatorTransform = cardAnimator.transform;
            Vector3 spawnPosition = cardAnimatorTransform.position;
            float cardDepth = cardAnimatorTransform.localScale.z;
            float startingZPosition = spawnPosition.z - (cardDepth / 2f);
            float zGapBetweenCards = cardDepth / numberOfCardsToSpawn;
            
            for (int i = 1; i <= numberOfCardsToSpawn; i++)
            {
                spawnPosition.z = startingZPosition + (zGapBetweenCards * i);
                spawnedCards.Add(Instantiate(cardPrefab, spawnPosition, Quaternion.identity));
            }
        }
    }
}