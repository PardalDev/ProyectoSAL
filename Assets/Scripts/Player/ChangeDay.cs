using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ChangeDay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject luz;
    private Vector3 lightRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            Debug.Log("Rorating");

            lightRotation = new Vector3(10, 0, 0);
            luz.transform.eulerAngles = lightRotation;

        }
    }
}
