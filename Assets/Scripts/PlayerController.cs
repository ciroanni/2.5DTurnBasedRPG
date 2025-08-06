using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private LayerMask grassLayer;
    [SerializeField] private int stepsInGrass;
    [SerializeField] private int minStepsInGrass; // Minimum steps before an encounter
    [SerializeField] private int maxStepsInGrass; // Maximum steps before an encounter

    private PlayerControls playerControls;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private bool movingInGrass = false;
    private float stepTimer = 0f;
    private int stepsToEncounter = 10; // Number of steps to trigger an encounter

    private const string IS_WALKING = "IsWalk";
    private const string BATTLE_SCENE = "BattleScene";
    private const float TIME_PER_STEP = 0.5f;

    void Awake()
    {
        playerControls = new PlayerControls();
        CalculateStepsToNextEncounter();
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

        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f, grassLayer);
        movingInGrass = colliders.Length != 0 && moveDirection != Vector3.zero;
        if (movingInGrass)
        {
            stepTimer += Time.fixedDeltaTime;
            if (stepTimer >= TIME_PER_STEP)
            {
                stepsInGrass++;
                stepTimer = 0f;
                if (stepsInGrass >= stepsToEncounter)
                {
                    SceneManager.LoadScene(BATTLE_SCENE);
                }
            }
        }
    }

    private void CalculateStepsToNextEncounter()
    {
        stepsToEncounter = Random.Range(minStepsInGrass, maxStepsInGrass);
    }
}
