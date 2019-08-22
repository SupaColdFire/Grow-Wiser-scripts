using UnityEngine;
using UnityEngine.SceneManagement;

namespace KG.UI
{
    public class ChooseLevel : MonoBehaviour
    {
        [SerializeField] private int      sceneIDToLoad;
        [SerializeField] private Animator _animator;

        public void LoadScene()
        {
            var sceneId = sceneIDToLoad;
            SceneManager.LoadScene(sceneId);
        }

        public void InvokeLoadScene()
        {
            StartFadeAnimation();
            Invoke(nameof(LoadScene), 1);
        }

        public void StartFadeAnimation()
        {
            _animator.SetTrigger("FadeIn");
        }
    }
}