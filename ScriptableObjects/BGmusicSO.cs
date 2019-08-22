using UnityEngine;

namespace KG.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BGmusicSO", menuName = "BGmusicSO")]
    public class BGmusicSO : ScriptableObject
    {
        public AudioClip[]  bgmAudioClip;
    }
}