using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 7f;
    [SerializeField]
    float dashMultiplier = 5f;
    [SerializeField]
    float rotationSpeed = 3f;
    Joystick js;

    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController=GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        float moveY = Input.GetAxis("Vertical");
        /*Vector2 direction = js.Direction;
        if(direction!=Vector2.zero)
        {
            moveX= direction.x;
            moveY= direction.y;
        }*/
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveY *= dashMultiplier;
        }
        transform.Rotate(0, moveX * rotationSpeed, 0);
        characterController.Move(transform.forward*moveY*moveSpeed);
        
        GetComponentInChildren<Animator>().SetFloat("movement",GetComponent<Rigidbody>().velocity.magnitude);
    }
}
