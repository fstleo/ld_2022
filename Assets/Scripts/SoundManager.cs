using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SoundId
{
    Click,
    Lock,
    PartCashIn,
    Explosion
}

public class SoundManager : MonoBehaviour
{
    [Serializable]
    private class Sound
    {
        [SerializeField] private SoundId _id;
        [SerializeField] private AudioClip [] _clips;

        public AudioClip [] Clips => _clips;

        public SoundId ID => _id;
    }

    private const string SoundKey = "Sound";
    private const string MusicKey = "Music";

    private static SoundManager _instance;
    
    [SerializeField]
    private AudioSource _soundsSource;
    
    [SerializeField]
    private AudioSource _musicSource;

    public float SoundLevel
    {
        get => PlayerPrefs.GetFloat(SoundKey, 1f);
        set
        {
            PlayerPrefs.SetFloat(SoundKey, value);
            _soundsSource.volume = value;
        }
    }

    public float MusicLevel
    {
        get => PlayerPrefs.GetFloat(MusicKey, 0.1f) / 0.1f;
        set
        {
            PlayerPrefs.SetFloat(MusicKey, value * 0.1f);
            _musicSource.volume = value * 0.1f;
        }
    }

    [SerializeField] 
    private Sound[] _clips;

    private Dictionary<SoundId, AudioClip[]> _audioClips = new Dictionary<SoundId, AudioClip[]>();
    
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        
        _soundsSource.volume = SoundLevel;
        _musicSource.volume = MusicLevel;
        foreach (var audio in _clips)
        {
            _audioClips.Add(audio.ID, audio.Clips);
        }
    }

    public static void PlaySound(SoundId id)
    {
        _instance.Play(id);
    }

    private void Play(SoundId id)
    {
        if (_audioClips.TryGetValue(id, out var clips))
        {
            var clip = clips[Random.Range(0, clips.Length)];
            if (clip == null)
            {
                Debug.LogError($"Clip for {id} is null");
            }
            else
            {
                _soundsSource.PlayOneShot(clip);    
            }
            
        }
    }
    
}