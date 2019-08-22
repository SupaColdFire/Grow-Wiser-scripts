using KG.Gameplay;
using KG.ScriptableObjects;
using UnityEngine;

namespace KG.UI
{
    [RequireComponent(typeof(AudioSource))]
    public class BGM : MonoBehaviour
    {
        private BackgroundMusicManager _bgmManager;
        private static BGM _bgmInstance;
        private string keyForMusic = "Music";

        private void Awake()
        {
            DontDestroyOnLoad(this);
            PlayerPrefs.SetInt(keyForMusic, 1);
            if (_bgmInstance == null)
            {
                _bgmInstance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _bgmManager = GetComponent<BackgroundMusicManager>();
             _bgmManager.PlayBGMAudio();
        }

        public void ToggleAudio()
        {
            _bgmManager.MuteBGM();
        }
    }
}