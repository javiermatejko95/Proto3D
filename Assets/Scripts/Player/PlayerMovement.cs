using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private Transform groundCheck = null;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    #endregion

    #region PRIVATE_FIELDS
    private CharacterController characterController = null;
    private Vector3 velocity = new Vector3();
    private bool isGrounded = false;
    #endregion

    #region UNITY_CALLS

    #endregion

    #region INITIALIZATION
    public void Init(CharacterController characterController)
    {
        this.characterController = characterController;
    }

    public void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
    #endregion
}
