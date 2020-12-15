using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovements : MonoBehaviour {

    // Rotation
    public float m_rotationAccelerationLR = 1.5f; // Acc�l�ration pour atteindre la vitesse de roulis de "croisi�re"
    public float m_rotationAccelerationUD = 1.0f; // Acc�l�ration pour atteindre la vitesse de tangage de "croisi�re"
    private float m_actualRotation_LR = 0.0f; // Left/Right
    private float m_actualRotation_UD = 0.0f; // Up/Down
    public float m_rotationSpeedLR = 5.0f; // Vitesse de roulis de "croisi�re"
    public float m_rotationSpeedUD = 5.0f; // Vitesse de tangage de "croisi�re"

    private float m_angleLR = 0.0f; // Angle actuel Gauche/Droite
    private float m_angleUD = 0.0f; // Angle actuel Haut/Bas
    // Speed
    public float m_accelerationSpeed = 0.3f; // Acc�l�ration pour atteindre la vitesse de "croisi�re"
    private float m_actualSpeed = 0.0f;
    public float m_speedMax = 1.0f; // Vitesse de "croisi�re"

    private Vector3 m_vector3;

    //Commands
    public float m_up_down = 0.0f; // Gradient Haut/bas
    public float m_left_right = 0.0f; // Gradient Gauche/droite
    public float m_speed = 0.0f; // Gradient de vitesse


    // Start is called before the first frame update
    void Start() {
        m_vector3 = this.transform.localPosition;
        m_angleLR = this.transform.localRotation.y;
        m_angleUD = this.transform.localRotation.z;
    }

    // Update is called once per frame
    void Update() {

        // Rotation
        m_actualRotation_LR += ((m_rotationSpeedLR * m_left_right) > m_actualRotation_LR ? m_rotationAccelerationLR : -m_rotationAccelerationLR) * Time.deltaTime;
        m_actualRotation_UD += ((m_rotationSpeedUD * m_up_down) > m_actualRotation_UD ? m_rotationAccelerationUD : -m_rotationAccelerationUD) * Time.deltaTime;

        m_angleLR += m_actualRotation_LR * Time.deltaTime;

        this.transform.localRotation = Quaternion.Euler((m_actualRotation_LR * -1), m_angleLR, m_actualRotation_UD);

        // Speed

        m_actualSpeed += ((m_speedMax * m_speed) > m_actualSpeed ? m_accelerationSpeed : -m_accelerationSpeed) * Time.deltaTime;

        m_vector3.x += m_actualSpeed * Mathf.Cos(m_angleLR * Mathf.Deg2Rad) * Mathf.Cos(m_actualRotation_UD * Mathf.Deg2Rad) * Time.deltaTime; // Axe X
        m_vector3.z += m_actualSpeed * -Mathf.Sin(m_angleLR * Mathf.Deg2Rad) * Mathf.Cos(m_actualRotation_UD * Mathf.Deg2Rad) * Time.deltaTime; // Axe Z
        m_vector3.y += m_actualSpeed * Mathf.Sin(m_actualRotation_UD * Mathf.Deg2Rad) * Time.deltaTime; // Up and Down

        this.transform.localPosition = m_vector3;

    }
}
