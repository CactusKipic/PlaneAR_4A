using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InstantiatePrefabOnTouch : MonoBehaviour
{
    Camera m_Camera;
    public LayerMask m_layerMask = 0x110;
    public GameObject m_prefabToInstantiate = null;


    // Start is called before the first frame update
    void Start()
    {
        m_Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
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
            GameObject prefabInstantiated = Instantiate(m_prefabToInstantiate);
            if (prefabInstantiated && instantiate)
            {
                prefabInstantiated.transform.position = raycastHit.point;
                prefabInstantiated.transform.parent = raycastHit.collider.transform;
                Debug.Log("The prefab is instantiated on the plane.");
            } 
        }
        else
        {
            GameObject prefabInstantiated = Instantiate(m_prefabToInstantiate);
            if (prefabInstantiated && instantiate)
            {
                prefabInstantiated.transform.position = this.transform.position + this.transform.forward;
                prefabInstantiated.transform.parent = this.transform;
                Debug.Log("The prefab is instantiated on the plane.");
            }
            //Debug.LogError("The prefab cannot be instantiated, no plane is detected.");
        }
    }
}
