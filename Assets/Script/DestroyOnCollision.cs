using System.Runtime.CompilerServices;
using UnityEngine;

namespace CodeGraph.UnityCourse.Enemies.CharacterController
{
    public class DestroyOnCollision : MonoBehaviour
    {
        private void TauntAndDamage()
        {
            GameManager.Instance.DecreasePlayerHP(1);
            Debug.Log("Player lose 1PV. "+GameManager.Instance.PlayerHP+"PV left");
        }
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.CompareTag("Player")|| collision.CompareTag("Projectile"))
            {
                Destroy(gameObject);
                if (collision.CompareTag("Player"))
                {
                    TauntAndDamage();
                    Debug.Log("la fonction est utilisée");
                }
            }
        }
    }
}
