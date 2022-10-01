using UnityEngine;

public class PartsHolder
{
    private readonly int _partsBurst;
    private readonly GameObject _partPrefab;

    public PartsHolder(int partsBurst, GameObject partPrefab)
    {
        _partsBurst = partsBurst;
        _partPrefab = partPrefab;
    }

    private void ThrowPart()
    {
        for (int i = 0; i < _partsBurst; i++)
        {
            var part = Object.Instantiate(_partPrefab).GetComponent<Part>();
            part.Collected += PartCollected;
        }
    }

    private void PartCollected(Part part)
    {
        ScoresHolder.Scores++;
        Object.Destroy(part.gameObject);
    }
}