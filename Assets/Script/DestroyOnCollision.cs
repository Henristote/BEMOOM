using System.Runtime.CompilerServices;
using UnityEngine;

namespace CodeGraph.UnityCourse.Enemies.CharacterController
{
    public class DestroyOnCollision : MonoBehaviour
    {
        public GameObject player;
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject == player)
            {
                Destroy(gameObject);
            }
        }
    }
}
