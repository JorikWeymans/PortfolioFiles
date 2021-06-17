//Created by Jorik Weymans 2021

using UnityEngine;
using UnityEngine.Audio;

public sealed class PlayerSoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _AttackAudio = null;
    [SerializeField] [Range(0, .5f)] private float _PitchRandomRange = 0.3f;

    [SerializeField] private AudioClip[] _AttackClips = null;
    [SerializeField] private AudioClip[] _DamageClips = null;
    
    private float _DefaultPitch = 0.0f;

    private void Awake()
    {
        _DefaultPitch = _AttackAudio.pitch;
    }
    public void PlayAttackSound()
    {
        _AttackAudio.pitch = _DefaultPitch + Random.Range(-_PitchRandomRange, _PitchRandomRange);
        _AttackAudio.clip = _AttackClips[Random.Range(0,_AttackClips.Length - 1)];

        _AttackAudio.Play();
    }

    public void PlayDamageSound()
    {
        _AttackAudio.pitch = _DefaultPitch + Random.Range(-_PitchRandomRange, _PitchRandomRange);
        _AttackAudio.clip = _DamageClips[Random.Range(0, _AttackClips.Length - 1)];

        _AttackAudio.Play();
    }
}