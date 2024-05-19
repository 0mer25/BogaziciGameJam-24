using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float dashPower;
    [SerializeField] private float dashCoolDown;
    [SerializeField] private Transform model;
    [SerializeField] private Animator animator;
    private BoxCollider boxCollider;
    private Rigidbody rb;
    float vertical = 0f;
    float horizontal = 0f;
    bool isDashing;
    private void Awake() 
    {
        rb  = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update() 
    {
        if(vertical == 0 && horizontal == 0)
        {
            animator.SetBool("isRunning" , false);
        }
        else
        {
            animator.SetBool("isRunning" , true);
        }
    }
    private void FixedUpdate() 
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            isDashing = true;
            Dash();
        }

        rb.velocity = movementSpeed * Time.deltaTime * new Vector3(horizontal , 0f , vertical);
        if(!(vertical == 0 && horizontal == 0))
        {
            IdleRotation(horizontal , vertical);
        }
    } 

    private void IdleRotation(float horizontal, float vertical)
    {
        var rotation = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        model.rotation = Quaternion.Slerp(model.rotation , Quaternion.Euler(0f, rotation, 0f) , .2f);
    }

    private void Dash()
    {
        boxCollider.enabled = false;

        rb.AddForce(model.forward * dashPower , ForceMode.VelocityChange);

        transform.DOScale(transform.localScale , .15f)
            .OnComplete(() => 
            {
                boxCollider.enabled = true;
            });

        transform.DOScale(transform.localScale , dashCoolDown)
            .OnComplete(() => 
            {
                isDashing = false;
            });
    }
}
