using UnityEngine;

public class PartsSpawner : MonoBehaviour
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

    private void ThrowPart(Vector3 explosionPosition)
    {
        for (int i = 0; i < _partsBurst; i++)
        {
            var spawnPointPosition = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
            var part = Instantiate(_partPrefab,spawnPointPosition , Quaternion.identity).GetComponent<Part>();
            part.Throw((spawnPointPosition - transform.position).normalized);
            part.Collected += PartCollected;
        }
    }

    private void PartCollected(Part part)
    {
        ScoresHolder.OnPlayer++;
        Destroy(part.gameObject);
    }
}