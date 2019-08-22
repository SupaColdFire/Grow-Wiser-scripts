using KG.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace KG.UI
{
        public class SoundToggle : MonoBehaviour
        {
            private Toggle _toggle;

            private BGM _bgm;
                // private BGM _bgm;
            public AudioSource Music;
            
            
            private void Awake()
            {
                  Music = GameObject.FindGameObjectWithTag("BGM").GetComponentInChildren<AudioSource>();
            }

            private void OnEnable()
            {
                if (_toggle == null)
                {
                    _toggle = GetComponent<Toggle>();  
                }
           
                _toggle.isOn = Settings.Instance.AudioEnabled;
            }

            public void SoundStateChanged()
            {
                if (_toggle.isOn)
                {
                    Debug.Log("Sound on");
                    Settings.Instance.AudioEnabled = true;
                    Music.mute = false;
                }
                else
                {
                    Debug.Log("Sound off");
                    Settings.Instance.AudioEnabled = false;
                    Music.mute = true;
                }
            }
        }     
}

        
