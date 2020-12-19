using Mirror;
using UnityEngine;

public class CharacterMovementMultiplayer : NetworkBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private CharacterController controller = null;

    private Vector2 previousInput;

    private Controles controles;

    private Controles Controles
    {
        get
        {
            if (controles != null) { return controles; }
            return controles = new Controles();
        }
    }

    public override void OnStartAuthority()
    {
        enabled = true;
        Controles.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        Controles.Player.Move.canceled += ctx => ResetMovement();
    }

    [ClientCallback]
    private void OnEnable() => Controles.Enable();

    [ClientCallback]
    private void OnDisable() => Controles.Disable();

    [ClientCallback]
    private void Update() => Move();

    [Client]
    private void SetMovement(Vector2 movement) => previousInput = movement;

    [Client]
    private void ResetMovement() => previousInput = Vector2.zero;

    [Client]
    private void Move()
    {
        Vector3 right = controller.transform.right;
        Vector3 forward = controller.transform.up;
        right.z = 0f;
        forward.z = 0f;

        Vector3 movement = right.normalized * previousInput.x + forward.normalized * previousInput.y;

        controller.Move(movement * movementSpeed * Time.deltaTime);
    }
}

