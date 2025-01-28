using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    //[SerializeField]
    //private InputActionReference fireAction;
    //[SerializeField]
    //private SpawnerOverTime spawner;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float Lauchforce = 30f;
    [SerializeField] private float destroyAfterSeconds = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //fireAction.action.Enable();
        rb.linearVelocity = transform.forward*Lauchforce;
        Destroy(gameObject, destroyAfterSeconds);
    }
}
