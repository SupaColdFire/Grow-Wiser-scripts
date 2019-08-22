using KG.ScriptableObjects;
using UnityEngine;

namespace KG.Gameplay
{
    public class BackgroundMusicManager : MonoBehaviour
    {
        [SerializeField] private BGmusicSO bgMusicSO;
        private AudioSource _audioSource;
        private AudioClip _bgmAudio;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            PlayMusicClips();
        }

        private void PlayMusicClips()
        {
            _bgmAudio = bgMusicSO.bgmAudioClip[Random.Range(0,bgMusicSO.bgmAudioClip.Length)];
        }
        
        public void PlayBGMAudio()
        {
            _audioSource.clip = _bgmAudio;
            _audioSource.Play();
        }
        public void MuteBGM()
        {
            _audioSource.mute = !_audioSource.mute;
        }
    }
}