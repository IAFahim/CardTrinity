using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace View
{
    public class CardSpawnerForAnimation : MonoBehaviour
    {
        public Animator cardAnimator; // Animator for the card animation
        public GameObject cardPrefab; // Prefab of the card to spawn
        public int numberOfCardsToSpawn = 52; // Number of cards to spawn
        public Transform cardSpawnTransform; // Transform of the card spawn point
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
                spawnPosition.x = i * 0.5f;
                spawnedCards.Add(Instantiate(cardPrefab, spawnPosition, Quaternion.identity, cardSpawnTransform));
            }
            cardSpawnTransform.transform.DOLocalMove(new Vector3(25, 0, 0), 1f);
        }
        
        
    }
}