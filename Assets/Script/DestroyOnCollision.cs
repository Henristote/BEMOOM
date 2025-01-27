using System.Runtime.CompilerServices;
using UnityEngine;

namespace CodeGraph.UnityCourse.Enemies.CharacterController
{
    public class DestroyOnCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.CompareTag("Player")|| collision.CompareTag("Projectile"))
            {
                    Destroy(gameObject);
            }
        }
    }
}
