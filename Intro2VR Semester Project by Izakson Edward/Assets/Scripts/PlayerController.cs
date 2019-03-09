using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player components & Vars
    Rigidbody playerRigidBody;
    public Camera playerCamera;
    public float speed;
    public bool canWalk;

    //Jumping on Double Tap
    public float jumpForce;
    public bool canJump;


    // Shooting components & var's
    public float damage;


    private void OnEnable()
    {
        InputManager.im_Instance.OnLongTouchEvent += UpdateCanWalk;
        InputManager.im_Instance.OnSingleTapEvent += Shoot;
        //TODO Double tap
    }

    private void OnDisable()
    {
        InputManager.im_Instance.OnLongTouchEvent -= UpdateCanWalk;
        InputManager.im_Instance.OnSingleTapEvent -= Shoot;

        //TODO Double tap

    }

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerCamera = FindObjectOfType<Camera>();
    }

    private void UpdateCanWalk()
    {
        canWalk = !canWalk;
    }

    //TODO jumping
    private void UpdateCanJump()
    {
        canJump = !canJump;
    }

    private void FixedUpdate()
    {
        if (canWalk)
        {
            Vector3 cameraForward = GameManager.instance._cameraTransform.forward;

            playerRigidBody.MovePosition(transform.position + cameraForward * speed * Time.deltaTime);
        }
    }

    void Jump()
    {
        playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
