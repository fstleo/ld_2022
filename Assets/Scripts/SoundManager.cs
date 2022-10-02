using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SoundId
{
    Click,
    Lock,
    PartCashIn,
    Explosion,
    Hiss
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

    private Dictionary<SoundId, AudioSource> _loopSounds = new Dictionary<SoundId, AudioSource>();

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

    public static void PlayLoop(SoundId id)
    {
        _instance.PlayLooped(id);
    }

    public static void StopLoop(SoundId id)
    {
        _instance.StopLooped(id);
    }

    private AudioClip GetRandomClip(SoundId id)
    {
        return _audioClips.TryGetValue(id, out var clips) ? clips[Random.Range(0, clips.Length)] : null;
    }
    
    private void Play(SoundId id)
    {
        _soundsSource.PlayOneShot(GetRandomClip(id));
    }

    private void PlayLooped(SoundId id)
    {
        if (_loopSounds.ContainsKey(id))
        {
            return;
        }
        var audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = SoundLevel;
        audioSource.clip = GetRandomClip(id);
        audioSource.loop = true;
        audioSource.Play();
        _loopSounds.Add(id, audioSource);
    }

    private void StopLooped(SoundId id)
    {
        if (_loopSounds.TryGetValue(id, out var soundSource))
        {
            Destroy(soundSource);
            _loopSounds.Remove(id);
        }
    }
    
}