using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private CharacterMovement charMov;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        charMov = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f && PlayerStat.Death == false)
        {
            animator.SetBool("isRunning", true);

            animator.SetFloat("xDir", direction.x);
            animator.SetFloat("yDir", Mathf.Abs(direction.z));

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                charMov.setPlayerSpeed(10f);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                charMov.setPlayerSpeed(6f);
            }

            /*
            if (Input.GetMouseButton(0))
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isPunching", true);
            }
            */

            
            if (Input.GetMouseButton(1))
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isRolling", true);
            }
            
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isRolling", false);
            animator.SetBool("isPunching", false);
        }
    }
}
