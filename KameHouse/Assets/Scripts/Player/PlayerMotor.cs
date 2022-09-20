using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    public static PlayerMotor Singleton;

    private Rigidbody _rb;

    #region Inputs
    
    [Header("Inputs")]
    public CurrentController currentController;
    public enum CurrentController { Gamepad, Keyboard }

    private PlayerInputs _inputs;
    
    #endregion

    #region PlayerStates

    [Header("States")]
    public MoveState moveState;
    public enum MoveState{ Stand, Move, Freeze }

    public MoveMode moveMode;
    public enum MoveMode{ Walk, Run}

    public bool isJumping;
    public bool isRotating;
    
    #endregion
    
    #region Movement Parameters

    [Header("Movement Parameters")]
    public float walkSpeed;
    public float runSpeed;
    [HideInInspector] public float currentSpeed;

    private Vector3 _moveInputDir;
    private Vector3 _playerDir;

    [Header("Rotation Parameters")] 
    public float rotSpeed;
    [SerializeField] private float _rotInputDir;

    [Header("Jump")] 
    public int jumpCount;
    private int _currentJumpCount;
    public float jumpLenght;

    #endregion

    private void OnEnable()
    {
        _inputs.Enable();
    }
    private void OnDisable()
    {
        _inputs.Disable();
    }

    private void Awake()
    {
        #region Singleton

        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }

        #endregion

        _inputs = new PlayerInputs();
        _rb = GetComponent<Rigidbody>();

        currentSpeed = runSpeed;
    }

    private void Update()
    {
        #region Input Reader

        //Movement
        _inputs.Normal.Move.started += Move;
        _inputs.Normal.Move.performed += Move;
        _inputs.Normal.Move.canceled += Move;

        //Rotation
        _inputs.Normal.Rotate.started += Rotate;
        _inputs.Normal.Rotate.performed += Rotate;
        _inputs.Normal.Rotate.canceled += Rotate;
        
        //Jump
        _inputs.Normal.Jump.started += Jump;
        _inputs.Normal.Jump.performed += Jump;
        _inputs.Normal.Jump.canceled += Jump;
        #endregion
        
        //Move
        if (moveState == MoveState.Move)
        {
            //use transform.forward to move around the forward of the object
            if (_moveInputDir.z != 0)
            {
                transform.position += transform.forward * (_moveInputDir.z * (currentSpeed * Time.deltaTime));
            }

            if (_moveInputDir.x != 0)
            {
                transform.position += transform.right * (_moveInputDir.x * (currentSpeed * Time.deltaTime));
            }
        }
        
        //Rotate
        if (isRotating)
        {
            transform.Rotate(new Vector3(0, _rotInputDir *(rotSpeed * Time.deltaTime), 0));
        }
    }

    private float DistanceToGround()
    {
        float distance;
        
        if (Physics.Raycast(transform.position, -transform.up, out var hit, 100))
        {
            distance = hit.distance;
        }
        else
        {
            distance = 0;
        }

        return distance;
    }
    
    private void Move(InputAction.CallbackContext ctx)
    {
        //x => x y => z
        _moveInputDir = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);

        if (moveState != MoveState.Freeze)
        {
            if (ctx.started)
            {
                moveState = MoveState.Move;
            }
        }

        if (ctx.canceled)
        {
            moveState = MoveState.Stand;
        }
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (DistanceToGround() < 3.7f && _currentJumpCount < jumpCount) //normal distance at ground = 3.7f
            {
                //Do Jump
                Vector3 jumpForce = new Vector3(0, jumpLenght, 0);
                _rb.AddForce(jumpForce, ForceMode.Impulse);
                _currentJumpCount++;
                
                AudioManager.Singleton.PlaySound("Jump");
            }
        }
    }
    
    private void Rotate(InputAction.CallbackContext ctx)
    {
        _rotInputDir = -ctx.ReadValue<float>();

        if (ctx.started)
        {
            isRotating = true;
        }

        if (ctx.canceled)
        {
            isRotating = false;
        }
        
    }


    #region Collisions & Triggers

    private void OnCollisionEnter(Collision collision)
    {
        if (DistanceToGround() <= 3.7f)
        {
            _currentJumpCount = 0;
        }
    }

    #endregion
}
