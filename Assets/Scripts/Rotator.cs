using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour { 

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(20, 30, 25) * Time.deltaTime);
    }
}
