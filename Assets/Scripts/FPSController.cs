using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{

    public float m_speed;
    float m_yaw;
    float m_pitch;

    public Transform m_PitchController;

    public float m_mouseSensitivityX;
    public float m_mouseSensitivityY;

    public bool flag;

    public float m_angleVisionY;

    public KeyCode jump;
    public float m_jumpImpulse;

    public KeyCode run;
    public float m_incrementalSpeed;
    private bool m_sprinting;
    private Camera m_camera;

    private CharacterController m_cc;
    private Vector3 m_front;
    private Vector3 m_right;
    private Vector3 m_movement;

    private float m_verticalVelocity;
    private bool m_OnGrounded;
    private const float m_gravity = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        m_yaw = transform.rotation.x;
        m_pitch = transform.rotation.y;
        m_cc = GetComponent<CharacterController>();
        m_camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputRotation();
        InputMovement();

        if (Input.GetKeyDown(jump))
        {
            m_verticalVelocity = m_jumpImpulse;
        }
        if (Input.GetKeyDown(run))
        {
            m_sprinting = true;
            m_camera.fieldOfView = 40.0f;
        }
        if (Input.GetKeyUp(run))
        {
            m_sprinting = false;
            m_camera.fieldOfView = 60.0f;
        }
    }

    private void InputMovement()
    {
        m_front = transform.forward * Input.GetAxis("Vertical");
        m_right = transform.right * Input.GetAxis("Horizontal");

        m_movement = m_front + m_right;
        m_verticalVelocity += m_OnGrounded ? 0 : m_gravity * Time.deltaTime;
        m_movement.y = m_verticalVelocity;
        float m_multiplier = m_sprinting ? m_incrementalSpeed : 1;
        CollisionFlags collision = m_cc.Move(m_movement * m_speed * m_multiplier * Time.deltaTime);
        if (collision.Equals(CollisionFlags.Below))
        {
            m_OnGrounded = true;
            m_verticalVelocity = 0f;
        }
        else
        {
            m_OnGrounded = false;
        }
    }

    private void InputRotation()
    {
        Cursor.lockState = CursorLockMode.Locked;
        float mousePositionX = Input.GetAxis("Mouse X");
        float mousePositionY = Input.GetAxis("Mouse Y");

        if (Mathf.Abs(m_pitch) < m_angleVisionY / 2 ||
            (m_pitch > m_angleVisionY / 2 && mousePositionY > 0) || //eje invertido
            m_pitch < -m_angleVisionY / 2 && mousePositionY < 0)
        {
            m_pitch += flag ?
                mousePositionY * Time.deltaTime * m_mouseSensitivityY * 1 :
                mousePositionY * Time.deltaTime * m_mouseSensitivityY * -1;
        }
        m_yaw += mousePositionX * Time.deltaTime * m_mouseSensitivityX;

        transform.rotation = Quaternion.Euler(0.0f, m_yaw, 0.0f);
        m_PitchController.localRotation = Quaternion.Euler(m_pitch, 0.0f, 0.0f);
    }
}
