using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.0f;

    public VirtualJoystick joystick;

    public Transform target;
    public Transform camTrans;

    Animator animator;
    float animatorSpeed = 0f;
    private bool hasAnimator;

    [SerializeField] private bool isGrounded = false;

    private Rigidbody rigid;

    public float dirH, dirV;

    public float turnSpeed = 10f;

    AudioSource audioSource;
    public AudioClip walkSound;
    public AudioClip jumpSound;

    void Start()
    {
        hasAnimator = TryGetComponent(out animator);
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        if (hasAnimator)
        {
            animator.applyRootMotion = false;
        }

    }


    void Update()
    {
        dirH = joystick.Horizontal();
        dirV = joystick.Vertical();

    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            Vector3 velocity = Time.deltaTime * moveSpeed * InputDirection();
            rigid.MovePosition(transform.position + velocity);
            
        }
        
    }

    private void LateUpdate()
    {
        Rotation();
    }

    public Vector3 InputDirection()
    {

        Vector3 dirMove = Vector3.zero;
        dirMove += camTrans.forward * dirV;
        dirMove += camTrans.right * dirH;

        if (dirMove.magnitude > 1f)
        {
            dirMove.Normalize();
        }
        //dirMove.y = 0f;
        animatorSpeed = dirMove.magnitude;

        if (hasAnimator)
        {
            animator.SetFloat("Speed", animatorSpeed);
            
        }
        
        return dirMove;
    }

    private void Rotation()
    {
        Vector3 MoveDirection = InputDirection();
        if (MoveDirection.magnitude >= 0.001f)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + dirH, transform.rotation.eulerAngles.z);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(walkSound, .5f);
            }
            else
        {
            audioSource.Stop();
        }
        }
        
    }


    public void Jump(float jumpForce)
    {
        float jumpPower = jumpForce * Time.deltaTime;

        if (isGrounded)
        {
            
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            if(jumpForce > 10f && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(jumpSound, 1f);
                isGrounded = false;
            }
            else
            {
                audioSource.Stop();
            }

            if (hasAnimator)
            {
                animator.SetTrigger("Jump");
            }
        }
        



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void Finish()
    {
        Debug.Log("Finish");
    }
}
