using UnityEngine;

namespace KG.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AudioSO", menuName = "AudioSO")]
    public class AudioScriptableObject : ScriptableObject
    {
        public AudioClip   buttonClickAudioClip;
        public AudioClip[] winAudioClips;
        public AudioClip[] correctPositionAudioClips;
    }
}