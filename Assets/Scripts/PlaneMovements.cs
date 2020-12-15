using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovements : MonoBehaviour {

    // Rotation
    public float m_rotationAcceleration = 1.5f; // Accélération pour atteindre la vitesse de rotation de "croisière"
    private float m_actualRotation = 0.0f;
    public float m_rotationSpeed = 5.0f; // Vitesse de rotation de "croisière"
    public float m_up_down = 0.0f; // Gradient Haut/bas
    public float m_left_right = 0.0f; // Gradient Gauche/droite
    private float m_angle = 0.0f;
    // Speed
    public float m_accelerationSpeed = 0.3f; // Accélération pour atteindre la vitesse de "croisière"
    private float m_actualSpeed = 0.0f;
    public float m_speedMax = 1.0f; // Vitesse de "croisière"
    public float m_speed = 0.0f;
    private Vector3 m_vector3;

    // Start is called before the first frame update
    void Start() {
        m_vector3 = this.transform.localPosition;
        m_angle = this.transform.localRotation.y;
    }

    // Update is called once per frame
    void Update() {

        // Rotation
        m_actualRotation += (m_rotationSpeed > m_actualRotation ? m_rotationAcceleration : -m_rotationAcceleration) * Time.deltaTime;

        m_angle += m_actualRotation * Time.deltaTime;

        this.transform.localRotation = Quaternion.Euler((m_actualRotation * -1), m_angle, 0.0f);

        // Speed

        m_actualSpeed += (m_speed > m_actualSpeed ? m_accelerationSpeed : -m_accelerationSpeed) * Time.deltaTime;

        m_vector3.x = m_vector3.x + m_actualSpeed * Mathf.Cos(m_angle * Mathf.Deg2Rad) * Time.deltaTime;
        m_vector3.z = m_vector3.z + m_actualSpeed * -Mathf.Sin(m_angle * Mathf.Deg2Rad) * Time.deltaTime;

        this.transform.localPosition = m_vector3;

    }
}
