using UnityEngine;

[RequireComponent(typeof(PlayerMov))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;
    public bool OnGround;
    private Rigidbody rb;
   
    private PlayerMov motor;
    void Start()
    {
        motor = GetComponent<PlayerMov>();
        OnGround = true;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calc movement velocity as a 3D vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _MovHorizontal = transform.right * _xMov;
        Vector3 _MovVertical = transform.forward * _zMov;
        // Ainal movement vector
        Vector3 _velocity = (_MovHorizontal + _MovVertical).normalized * speed;
        // Apply movement
        motor.Move(_velocity);

        //Calc rotation as a 3D vector(turnning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0F) * lookSensitivity;

        //Apply rotation
        motor.Rotate(_rotation);

        //Calc rotation as a 3D vector(turnning around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotationX = _xRot * lookSensitivity;

        //Apply camera rotation
        motor.Rotatecamera(_cameraRotationX);

        if (OnGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector3(0f, 6f, 0f);
            //    OnGround = false;
            }
        }        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tamer"))
        {
            OnGround = true;
        }
    }
}
