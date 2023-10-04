using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{

    float m_yaw;
    float m_pitch;

    public Transform m_PitchController;

    public float m_mouseSensitivityX;
    public float m_mouseSensitivityY;

    public bool flag;

    public float angleVisionY;

    public KeyCode front;
    public KeyCode back;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode run;

    public float speed;
    public CharacterController cc;
    public Vector3 frontVector;
    public Vector3 rightVector;
    public Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        m_yaw = transform.rotation.x;
        m_pitch = transform.rotation.y;
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float mousePositionX = Input.GetAxis("Mouse X");
        float mousePositionY = Input.GetAxis("Mouse Y");

        if(Mathf.Abs(m_pitch)< angleVisionY / 2 ||
            (m_pitch > angleVisionY / 2 && mousePositionY > 0)|| //eje invertido
            m_pitch < -angleVisionY / 2 && mousePositionY < 0) {
            m_pitch += flag ?
                mousePositionY * Time.deltaTime * m_mouseSensitivityY * 1 :
                mousePositionY * Time.deltaTime * m_mouseSensitivityY * -1;
        }
        m_yaw += mousePositionX * Time.deltaTime * m_mouseSensitivityX;
 
        transform.rotation = Quaternion.Euler(0.0f, m_yaw, 0.0f);
        m_PitchController.localRotation = Quaternion.Euler(m_pitch, 0.0f, 0.0f);

        frontVector = transform.forward;
        rightVector = transform.right;
        
        frontVector = frontVector * Input.GetAxis("Vertical");
        rightVector = rightVector * Input.GetAxis("Horizontal");

        movement = frontVector + rightVector;
        cc.Move(movement * speed * Time.deltaTime);
    }
}
