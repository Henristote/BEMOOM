//using System.Collections;
//using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference moveActionReference;
    [SerializeField]
    private InputActionReference boostActionReference;
    [SerializeField]
    private InputActionReference shootActionReference;
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform SpawnPoint;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private const string ANIMATOR_BOOL_IS_RUNNING = "IsRunning";
    private const string ANIMATOR_BOOL_IS_HIT = "IsHit";
    private const string ANIMATOR_BOOL_IS_SHOOTING = "IsShoot";
    private const string enemy_layer_name = "Enemy";
    private float speed = 4f;
    private int enemyLayer;

    // Start is called before the first frame update
    private void Start()
    {
        moveActionReference.action.Enable();
        boostActionReference.action.Enable();
        shootActionReference.action.Enable();
        shootActionReference.action.started += OnStart;
        shootActionReference.action.canceled += OnStart2; 
        enemyLayer = LayerMask.NameToLayer(enemy_layer_name);


    }

    private void OnStart(InputAction.CallbackContext context)
    {
        animator.SetBool(ANIMATOR_BOOL_IS_SHOOTING, true);
        Instantiate(projectilePrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
    private void OnStart2(InputAction.CallbackContext context)
    {
        animator.SetBool(ANIMATOR_BOOL_IS_SHOOTING, false);
    }


    private void OnDestroy()
    {
        shootActionReference.action.started -= OnStart;
        shootActionReference.action.canceled-= OnStart2;


    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(enemy_layer_name))
        {
            animator.SetTrigger(ANIMATOR_BOOL_IS_HIT);
        }
    }
   
    public void Move()
    {
        animator.SetBool(ANIMATOR_BOOL_IS_RUNNING, false);
        Vector2 frameMovement = moveActionReference.action.ReadValue<Vector2>();
        Vector3 frameMovement3D = new(0, 0, frameMovement.y);
        if (frameMovement.x != 0)
        {
            transform.Rotate(new Vector3(0, (-1)*frameMovement.x * speed/2, 0));
        }
        Vector3 localMovement = transform.TransformDirection(frameMovement3D);

        Vector3 newPos;
        if (boostActionReference.action.IsPressed())
        {
            newPos = transform.position + localMovement * speed * Time.deltaTime * 5;
            animator.SetBool(ANIMATOR_BOOL_IS_RUNNING, newPos.magnitude > 0);
        }
        else
        {
            newPos = transform.position + localMovement * speed * Time.deltaTime;
        }

        transform.position = newPos;
    }

    // Update is called once per frame
    private void Update()
    {
        Move ();
    }
}
