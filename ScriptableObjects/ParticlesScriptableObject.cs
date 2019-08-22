using UnityEngine;

namespace KG.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ParticlesSO", menuName = "ParticlesSO")]
    public class ParticlesScriptableObject : ScriptableObject
    {
        public ParticleSystem[] particles;
    }
}