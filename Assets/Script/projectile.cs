using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private InputActionReference fireAction;
    [SerializeField]
    private SpawnerOverTime spawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireAction.action.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
