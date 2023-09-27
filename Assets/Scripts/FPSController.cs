using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{

    float m_Pitch;
    float m_Yaw;

    public Transform m_PitchController;

    public float m_mouseSensitivityX;
    public float m_mouseSensitivityY;

    public bool flag;

    public float angleVisionY;

    // Start is called before the first frame update
    void Start()
    {
        m_Pitch = transform.rotation.x;
        m_Yaw = transform.rotation.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePositionX = Input.GetAxis("Mouse X");
        float mousePositionY = Input.GetAxis("Mouse Y");

        if(Mathf.Abs(m_Yaw)< angleVisionY / 2 ||
            (m_Yaw > angleVisionY / 2 && mousePositionY > 0)|| //eje invertido
            m_Yaw < -angleVisionY / 2 && mousePositionY < 0) {
            m_Yaw += flag ?
                mousePositionY * Time.deltaTime * m_mouseSensitivityY * 1 :
                mousePositionY * Time.deltaTime * m_mouseSensitivityY * -1;
        }
        m_Pitch += mousePositionX * Time.deltaTime * m_mouseSensitivityX;
 
        transform.rotation = Quaternion.Euler(0.0f, m_Pitch, 0.0f);
        m_PitchController.localRotation = Quaternion.Euler(m_Yaw, 0.0f, 0.0f);
    }
}
