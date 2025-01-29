using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeGraph.UnityCourse.Enemies.CharacterController
{
    
    public class DestroyOnCollision : MonoBehaviour
    {
        private const string projectile_layer_name = "Projectile";
        private const string player_layer_name = "Player";
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(player_layer_name) || collision.gameObject.layer == LayerMask.NameToLayer(projectile_layer_name))
            {
                Destroy(gameObject);
                //Destroy(collision.gameObject);
                if (collision.gameObject.layer == LayerMask.NameToLayer(player_layer_name))
                {
                    GameManager.Instance.nb_life -= 1;
                    Debug.Log(GameManager.Instance.nb_life + " vies restantes");
                }
                if (collision.gameObject.layer == LayerMask.NameToLayer(projectile_layer_name))
                {
                    Destroy(collision.gameObject);
                    GameManager.Instance.score += 1;
                }
            }
        }
    }
}
