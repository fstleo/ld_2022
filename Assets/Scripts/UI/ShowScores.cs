using TMPro;
using UnityEngine;

public class ShowScores : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scores;
    [SerializeField] private TextMeshProUGUI _maxScores;

    private void Update()
    {
        if (_scores != null)
        {
            _scores.text = ScoresHolder.Scores.ToString();    
        }

        if (_maxScores != null)
        {
            _maxScores.text = ScoresHolder.MaximumScores.ToString();    
        }
    }
}