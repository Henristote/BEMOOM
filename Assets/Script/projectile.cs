using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    //[SerializeField]
    //private InputActionReference fireAction;
    //[SerializeField]
    //private SpawnerOverTime spawner;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float Lauchforce = 50f;
    [SerializeField] private float destroyAfterSeconds = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //fireAction.action.Enable();
        rb.linearVelocity = transform.forward*Lauchforce;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
}
