using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(MonsterMove))]
public class MonsterController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;
    [SerializeField]
    private float thrusterForce = 1000f;

    [Header("Spring Settings:")]
    [SerializeField]
    private JointDriveMode jointMode = JointDriveMode.Position;
    [SerializeField]
    private float jointSpring = 20f;
    [SerializeField]
    private float jointMaxForce = 40f;


    private ConfigurableJoint joint;
    private MonsterMove motor;
    void Start()
    {
        motor = GetComponent<MonsterMove>();
        joint = GetComponent<ConfigurableJoint>();
        SetJointSettings(jointSpring);
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

        //calc the thrusterforce based on player input
        Vector3 _thrusterForce = Vector3.zero;
        if (Input.GetButton("Jump"))
        {
            _thrusterForce = Vector3.up * thrusterForce;
            SetJointSettings(0f);
        }
        else
        {
            SetJointSettings(jointSpring);
        }

        //apply thrusterforce
        motor.ApplyThruster(_thrusterForce);
    }

    private void SetJointSettings(float _jointSpring)
    {
        joint.yDrive = new JointDrive { mode = jointMode, positionSpring = _jointSpring, maximumForce = jointMaxForce };
    }
}
