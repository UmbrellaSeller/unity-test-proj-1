using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 start = new Vector3(25, 0, 25);
    public CharacterController rb;
    public float Speed = 5;

    public float SpeedY = 2f;
    private float yaw = 0f;
    private float pitch = 0f;

    private float limit = 70f;

    private float Gravity = (9.36f);

    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = start;
        rb = GetComponent<CharacterController>(); 
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        var forward = playerCamera.transform.forward;
        var right   = playerCamera.transform.right;

        forward.y   = 0;
        right.y     = 0;

        forward.Normalize();
        right.Normalize();

        var desiredPos = forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal");
        rb.Move((desiredPos * Speed) * Time.deltaTime - new Vector3(0, Gravity * Time.deltaTime, 0));

        yaw += SpeedY * Input.GetAxis("Mouse X");
        pitch -= SpeedY * Input.GetAxis("Mouse Y");
        playerCamera.transform.rotation = Quaternion.Euler(new Vector3(Mathf.Clamp(pitch, -limit, limit), yaw, 0));

        Debug.Log(rb.isGrounded);

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("yeah");
        }
    }
}
