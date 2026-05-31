using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    private Vector3 Velocity;
    private Vector3 PlayerMovementInput;

    [SerializeField] private CharacterController Controller;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float Gravity = -9.81f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // gets the axis of the player for the Vector3
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);

        if (Controller.isGrounded)
        {
            Velocity.y = -1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Velocity.y = JumpForce;
            }
        }
        else
        {
            Velocity.y -= Gravity * -2f * Time.deltaTime;
        }

        Controller.Move(MoveVector * Speed * Time.deltaTime);
        Controller.Move(Velocity * Time.deltaTime);
    }
}
