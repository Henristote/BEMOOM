//using System.Collections;
//using System.Collections.Generic;
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
    private float speed = 4f;

    private bool shooting = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        moveActionReference.action.Enable();
        boostActionReference.action.Enable();
        shootActionReference.action.Enable();
    }

    public void Move()
    {
        Vector2 frameMovement = moveActionReference.action.ReadValue<Vector2>();
        Vector3 frameMovement3D = new Vector3(frameMovement.x, 0, frameMovement.y);
        Vector3 newPos;
        if (boostActionReference.action.IsPressed())
        {
            newPos = transform.position + frameMovement3D * speed * Time.deltaTime * 5;
        }
        else
        {
            newPos = transform.position + frameMovement3D * speed * Time.deltaTime;
        }
        transform.position = newPos;
        animator.SetBool("IsRunning", newPos.magnitude > 0);
    }
    public void Shoot()
    {
        if (shootActionReference.action.IsPressed() && shooting == false)
        {
            Instantiate(projectilePrefab, SpawnPoint.position, transform.rotation);
            shooting = true;
        } else
        {
            shooting = false;
        }
    }
    // Update is called once per frame
    private void Update()
    {
        Move ();
        Shoot();
        
        //var targetAngle = Mathf.Atan(newPos.x, newPos.y) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0.0f, targetAngle, 0.0f);
    }
}
