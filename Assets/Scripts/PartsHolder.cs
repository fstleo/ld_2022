using UnityEngine;

public class PartsHolder : MonoBehaviour
{
    [SerializeField]
    private  int _partsBurst;
    
    [SerializeField]
    private GameObject _partPrefab;

    [SerializeField] private Transform[] _spawnPoints;
    
    public void Init(Blast blast)
    {
        blast.Explosion += ThrowPart;
    }

    private void ThrowPart()
    {
        for (int i = 0; i < _partsBurst; i++)
        {
            var part = Object.Instantiate(_partPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity).GetComponent<Part>();
            part.Collected += PartCollected;
        }
    }

    private void PartCollected(Part part)
    {
        ScoresHolder.Scores++;
        Object.Destroy(part.gameObject);
    }
}