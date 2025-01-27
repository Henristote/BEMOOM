//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
//using static UnityEngine.GraphicsBuffer;
//using UnityEngine.Rendering;
//using UnityEngine.InputSystem.UI;
public class EnnemyController : MonoBehaviour

{
    public GameObject player;


    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position , 0.01f);
        Vector3 direction = transform.position - player.transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
