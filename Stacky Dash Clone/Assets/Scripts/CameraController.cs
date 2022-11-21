using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerFollow;
    Vector3 cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        cameraPos = transform.position - playerFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerFollow.transform.position + cameraPos, 10 * Time.deltaTime);
    }
}
