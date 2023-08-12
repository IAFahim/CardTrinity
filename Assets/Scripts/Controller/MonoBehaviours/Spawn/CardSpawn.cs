using System.Collections;
using UnityEngine;

namespace Controller.MonoBehaviours.Spawn
{
    public class CardSpawn : MonoBehaviour
    {
        public GameObject cardPrefab;
        public float distance = 1.0f;
        public int numCopies = 4;
        public float rotationInterval = 90.0f;

        private void OnValidate()
        {
            rotationInterval = 360.0f / numCopies;
        }

        private void Start()
        {
            rotationInterval = 360.0f / numCopies;
            StartCoroutine(DropAndRotateCards());
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            var currentTransform = transform;
            Gizmos.DrawRay(currentTransform.position, currentTransform.forward * distance);
            for (int i = 0; i < numCopies; i++)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawRay(currentTransform.position, Quaternion.Euler(0, i * rotationInterval, 0) * currentTransform.forward * distance);
            }
        }

        private IEnumerator DropAndRotateCards()
        {
            yield return new WaitForSeconds(.5f);

            for (int i = 0; i < numCopies; i++)
            {
                var position = transform.position;
                GameObject newCard = Instantiate(cardPrefab, position, Quaternion.identity);
                
                float angle = i * rotationInterval;

                Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;
                
                newCard.transform.position += direction * distance;

                yield return new WaitForSeconds(0.5f); 
            }
        }
    }
}