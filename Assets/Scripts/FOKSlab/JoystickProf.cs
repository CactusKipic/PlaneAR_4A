using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickProf : MonoBehaviour
{

    public float _horizontal = 0.0f;
    public float _vertical = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("z"))
            _vertical += 1.0f;
        if (Input.GetKeyUp("z"))
            _vertical -= 1.0f;

        if (Input.GetKeyDown("s"))
            _vertical -= 1.0f;
        if (Input.GetKeyUp("s"))
            _vertical += 1.0f;


        if (Input.GetKeyDown("q"))
            _horizontal -= 1.0f;
        if (Input.GetKeyUp("q"))
            _horizontal += 1.0f;

        if (Input.GetKeyDown("d"))
            _horizontal += 1.0f;
        if (Input.GetKeyUp("d"))
            _horizontal -= 1.0f;


        if(Input.GetKeyDown(KeyCode.Space))
        {
            _vertical = _horizontal = 0.0f;
        }
    }

}
