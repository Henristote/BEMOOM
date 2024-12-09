using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference moveActionReference;
    [SerializeField]
    private InputActionReference boostActionReference;
    private Vector3 A;
    private Vector3 B;
    private float startTime;
    private float speed = 4f;
    
    // Start is called before the first frame update
    private void Start()
    {
        A = new Vector3(0, 0, 0);
        B = new Vector3(1, 0, 1);
        startTime = Time.time;
        moveActionReference.action.Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        //float x = Mathf.Sin(2 * Mathf.PI * 2 * Time.time);
        //transform.position = new Vector3(2 + x, transform.position.y, transform.position.z);
        //if (Input.GetKeyDown(KeyCode.Escape)) { 
        // startTime = Time.time;
        //}
        //float timeSinceStart= Time.time - startTime;

        Vector2 frameMovement = moveActionReference.action.ReadValue<Vector2>();
        Vector3 frameMovement3D = new Vector3(frameMovement.x, 0, frameMovement.y);
        Vector3 newPos = transform.position + frameMovement3D * speed * Time.deltaTime;
        transform.position = newPos;
    }
}
