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
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerFollow.transform.position + cameraPos, 10 * Time.deltaTime);

        if (PlayerMovement.isCameraNewPos)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0.5f, 0, -1.4f), 20 * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(25, -15, 0), 20 * Time.deltaTime);
        }
    }
}
