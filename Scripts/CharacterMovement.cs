using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController movement;

    [SerializeField]
    private float playerSpeed = 6f;

    [SerializeField]
    private float playerMaXRotationSpeed = 0.1f;

    private float gravitation = 9.8f;

    [SerializeField]
    private Transform camera;

    private float playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Vector3 -> 3D (X, Y, Z)
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        Vector3 movementDirection = new Vector3();

        if(direction.magnitude >= 0.1f) {
            float playerAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float movementAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, playerAngle, ref playerVelocity, playerMaXRotationSpeed);

            movementDirection = Quaternion.Euler(0, playerAngle, 0) * Vector3.forward;
            movementDirection = movementDirection.normalized;

            transform.rotation = Quaternion.Euler(0, movementAngle, 0);

        }

        movementDirection.y += (gravitation * -1);
        movementDirection.x *= playerSpeed;
        movementDirection.z *= playerSpeed;

        movement.Move(movementDirection * Time.deltaTime);
    }

    public void setPlayerSpeed(float playerSpeed)
    {
        this.playerSpeed = playerSpeed;
    }

    public float getPlayerSpeed()
    {
        return this.playerSpeed;
    }

}
