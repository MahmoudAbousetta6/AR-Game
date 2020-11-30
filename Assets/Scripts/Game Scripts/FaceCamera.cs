using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{

    void Update()
    {
        Vector3 targetPostition = new Vector3(Camera.main.transform.position.x,
                                                transform.position.y,
                                                Camera.main.transform.position.z);
        transform.LookAt(targetPostition);
    }
}