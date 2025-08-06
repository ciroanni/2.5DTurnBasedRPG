using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer playerSprite;
    private Rigidbody rb;
    private Vector3 moveDirection;

    private const string IS_WALKING = "IsWalk";

    void Awake()
    {
        playerControls = new PlayerControls();
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        float x = playerControls.Player.Move.ReadValue<Vector2>().x;
        float z = playerControls.Player.Move.ReadValue<Vector2>().y;
        moveDirection = new Vector3(x, 0, z).normalized * speed;
        animator.SetBool(IS_WALKING, moveDirection != Vector3.zero);
        if (x != 0 && x < 0)
        {
            playerSprite.flipX = true;
        }
        else if (x != 0 && x > 0)
        {
            playerSprite.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * Time.fixedDeltaTime);
    }
}
