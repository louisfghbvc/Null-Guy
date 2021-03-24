using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float gravity;
    public float rotationSpeed;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        
        if (controller.isGrounded) {
            // moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            // this.rotation = new Vector3(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);
            this.rotation = new Vector3(0, Input.GetAxis("Horizontal") / 3, 0);
            if(Input.GetKey(KeyCode.UpArrow)){
                GetComponent<Animation>().Play("Run");
            }   
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        this.transform.Rotate(this.rotation);
    }
}
