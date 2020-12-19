using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InstantiatePrefabOnTouch : MonoBehaviour
{
    Camera m_Camera;
    public LayerMask m_layerMask = 0x110;
    public GameObject m_prefabToInstantiate = null;
    private GameObject m_instantiatedPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_instantiatedPrefab != null)
            return;
        if (m_prefabToInstantiate == null)
            return;
        bool instantiate = false;
        Vector3 position = Vector3.zero;
        if (Input.GetMouseButtonDown(0))
        {
            position = Input.mousePosition;
            instantiate = true;
        }
        if ((Input.touches.Length > 0 && Input.touches[0].phase == TouchPhase.Began))
        {
            position = Input.touches[0].position;
            instantiate = true;
        }
        if (!instantiate)
            return;
        Ray ray = m_Camera.ScreenPointToRay(position);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, 100.0f, m_layerMask))
        {
            m_instantiatedPrefab = Instantiate(m_prefabToInstantiate);
            if (m_instantiatedPrefab && instantiate)
            {
                m_instantiatedPrefab.transform.position = raycastHit.point;
                m_instantiatedPrefab.transform.parent = raycastHit.collider.transform;
                Debug.Log("The prefab is instantiated on the plane.");
            } 
        }
        else
        {
            m_instantiatedPrefab = Instantiate(m_prefabToInstantiate);
            if (m_instantiatedPrefab && instantiate)
            {
                m_instantiatedPrefab.transform.position = raycastHit.point;
                m_instantiatedPrefab.transform.parent = raycastHit.collider.transform;
                Debug.Log("The prefab is instantiated on the plane.");
            }
            //Debug.LogError("The prefab cannot be instantiated, no plane is detected.");
        }
    }
}
