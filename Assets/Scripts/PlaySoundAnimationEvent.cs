using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundAnimationEvent : MonoBehaviour
{
    [SerializeField]
    private SoundId _soundId;
    
    public void PlaySound()
    {
        SoundManager.PlaySound(_soundId);
    }
}
