using KG.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KG.Gameplay
{
    public class ParticleController : MonoBehaviour
    {
        [SerializeField] private ParticlesScriptableObject particlesSO;
        private ParticleSystem _particle;

        private void Awake()
        {
            _particle = particlesSO.particles[SceneManager.GetActiveScene().buildIndex - 1];
        }


        public void SpawnParticlesOnObject(Vector2 objectPosition)
        {
            Instantiate(_particle, objectPosition, Quaternion.identity);
        }
    }
}