using KG.ScriptableObjects;
using UnityEngine;

namespace KG.Gameplay
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioScriptableObject audioSO;

        private AudioSource _audioSource;
        private AudioClip   _winAudio;
        private AudioClip   _correctPositionAudio;
        private AudioClip   _buttonClickAudio;
        private bool        _winSfxPlayed;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            GetAudioClips();
        }

        private void GetAudioClips()
        {
            _winAudio = audioSO.winAudioClips[Random.Range(0, audioSO.winAudioClips.Length)];
            _correctPositionAudio =
            audioSO.correctPositionAudioClips[Random.Range(0, audioSO.correctPositionAudioClips.Length)];
            _buttonClickAudio = audioSO.buttonClickAudioClip;
        }

        public void PlayWinAudio()
        {
            if (!_winSfxPlayed) _audioSource.PlayOneShot(_winAudio);
        }

        public void PlayCorrectPositionAudio()
        {
            _audioSource.PlayOneShot(_correctPositionAudio);
        }

        public float GetWinAudioLength()
        {
            return _winAudio.length;
        }
        
        public void PlayButtionClickAudio()
        {
            _audioSource.PlayOneShot(_buttonClickAudio, 1);
        }
    }
}