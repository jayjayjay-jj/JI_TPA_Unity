using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool isHoldingWeapon;
    [SerializeField]
    private Animator animator;
    private CharacterMovement charMov;
    [SerializeField]
    private AudioSource runSound, punchSound, attackSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        charMov = GetComponent<CharacterMovement>();
        runSound.enabled = false;
        punchSound.enabled = false;
        attackSound.enabled = false;
        isHoldingWeapon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f && PlayerStat.Death == false)
        {
            runSound.enabled = true;
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
        }
        else
        {
            animator.SetBool("isRunning", false);
            runSound.enabled=false;
        }
        if (Input.GetMouseButton(0))
        {
            if (isHoldingWeapon == false){
                animator.SetTrigger("isPunching");
                punchSound.enabled = false;
                punchSound.enabled = true;
            }
            else if (isHoldingWeapon == true)
            {
                animator.SetTrigger("isAttacking");
                attackSound.enabled = false;
                attackSound.enabled = true;
            }
            
        }


        if (Input.GetMouseButton(1))
        {
            animator.SetBool("isRolling", true);
        }
        else
        {
            animator.SetBool("isRolling", false);
        }
    }
}
