using UnityEngine;

public class ParticleSystemTrigger : MonoBehaviour
{
   [SerializeField] private ParticleSystem particle;

   private void OnCollisionEnter2D(Collision2D col)
   {
         Instantiate(particle, transform.position, Quaternion.identity);
         Destroy(col.gameObject);
         Destroy(gameObject);
   }
}
