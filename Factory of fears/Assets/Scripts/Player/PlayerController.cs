using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.Hierarchy.Editor;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Transform firstPersonCamera;
    [SerializeField] private float mouseSensitivity = 2f;
    private float xRotation = 0f;

    [Header("Movement")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float gravity = -20f;
    private CharacterController controller;
    private Vector3 velocity;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference lookAction;
    [SerializeField] private InputActionReference sprintAction;

    [Header("Stamina")]
    [SerializeField] private float maxStamina = 90f;
    [SerializeField] private float stamina = 90f;
    [SerializeField] private float staminaDrain = 15f;
    [SerializeField] private float staminaRegen = 6f;
    [SerializeField] private Slider staminaBar;

    [Header("Health")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health = 100;
    [SerializeField] private Slider healthBar;

    [Header("Damage")]
    [SerializeField] private float damageCooldown = 1f;
    private float lastDamaged;
    private bool dead = false;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        health = maxHealth;
        stamina = maxStamina;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = health;
        }

        if (staminaBar != null)
        {
            staminaBar.maxValue = maxStamina;
            staminaBar.value = stamina;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (dead) { return; }
        CameraMove();
        PlayerMove();
        UpdateUI();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        lookAction.action.Enable();
        sprintAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        lookAction.action.Disable();
        sprintAction.action.Disable();
    }

    private void CameraMove()
    {
        Vector2 mouseInput = lookAction.action.ReadValue<Vector2>();

        float mouseX = mouseInput.x * mouseSensitivity * 0.05f;
        float mouseY = mouseInput.y * mouseSensitivity * 0.05f;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        firstPersonCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void PlayerMove()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        
        Vector3 movement = transform.right * input.x + transform.forward * input.y;
        movement = Vector3.ClampMagnitude(movement, 1f);

        bool moving = movement.sqrMagnitude > 0.01f;
        bool sprinting = sprintAction.action.IsPressed() && moving && stamina > 0f;
        float speed = walkSpeed;

        if (sprinting)
        {
            speed = sprintSpeed;
            stamina -= staminaDrain * Time.deltaTime;
        }

        else
        {
            stamina += staminaRegen * Time.deltaTime;
        }

        stamina = Mathf.Clamp(stamina, 0f, maxStamina);
        controller.Move(movement * speed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void UpdateUI()
    {
        if (healthBar != null)
        {
            healthBar.value = health;
        }

        if (staminaBar != null)
        {
            staminaBar.value = stamina;
        }
    }

    public void TakeDamage(int damage)
    {
        if (dead) { return; }

        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);

        UpdateUI();

        if (health <= 0)
        {
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        dead = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Game Over");
    }

    //For Health PickUp
    public void Heal(int amount)
    {}
}