using UnityEngine;

public class ScoresHolder
{
    private const string ScoreKey = "Scores";

    public static int MaximumScores 
    {
        get => PlayerPrefs.GetInt(ScoreKey, 0);
        private set => PlayerPrefs.SetInt(ScoreKey, value);
    }

    private static int _scores;
    public static int Scores
    {
        get => _scores;
        set
        {
            _scores = value;
            Debug.Log(_scores);
            if (_scores > MaximumScores)
            {
                MaximumScores = _scores;
            }
        }
    }

    public static int OnPlayer
    {
        get;
        set;
    }

    public static void ApplyScores()
    {
        Scores += OnPlayer;
        OnPlayer = 0;
    }
}