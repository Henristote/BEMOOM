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

        shootActionReference.action.canceled += (_) => shooting = false;
    }

    public void Move()
    {
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
            animator.SetBool("IsRunning", newPos.magnitude > 0);
        }
        else
        {
            newPos = transform.position + localMovement * speed * Time.deltaTime;
        }

        transform.position = newPos;
    }
    public void Shoot()
    {
        if (shootActionReference.action.IsPressed() && shooting == false)
        {
            Instantiate(projectilePrefab, SpawnPoint.position, SpawnPoint.rotation);
            shooting = true;
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
