using UnityEngine;

public class PutPartsToTheShipTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoresHolder.ApplyScores();
        }
    }
}