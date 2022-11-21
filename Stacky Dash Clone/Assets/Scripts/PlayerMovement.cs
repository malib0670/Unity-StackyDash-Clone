using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance { set; get; }
    public Vector3 swipeDelta, startTouch, distance, currentPos;
    public LayerMask layer;
    public GameObject tapToPlay;
    RaycastHit hit;

    public bool swipeLeft, swipeRight, swipeDown, swipeUp;
    public bool isMove, isCollision;
    public static bool isGameActive;
    float deadZone = 100;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        isMove = true;
        instance = this;
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        swipe();
        swipeMovement();
        raycastMethod();
    }

    public void swipe()
    {
        if (isGameActive)
        {
            if (Input.touchCount > 0)
            {
                tapToPlay.SetActive(false);

                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    startTouch = Input.GetTouch(0).position;
                }

                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    currentPos = Input.GetTouch(0).position;
                    distance = currentPos - startTouch;

                    if (isCollision == true)
                    {
                        if (distance.x > deadZone)
                        {
                            isMove = true;
                            transform.rotation = Quaternion.Euler(0, 90, 0);
                            swipeRight = true;
                            swipeLeft = false;
                            swipeDown = false;
                            swipeUp = false;
                        }

                        else if (distance.x < -deadZone)
                        {
                            isMove = true;
                            transform.rotation = Quaternion.Euler(0, -90, 0);
                            swipeRight = false;
                            swipeLeft = true;
                            swipeDown = false;
                            swipeUp = false;
                        }

                        else if (distance.y > deadZone)
                        {
                            isMove = true;
                            transform.rotation = Quaternion.Euler(0, 360, 0);
                            swipeRight = false;
                            swipeLeft = false;
                            swipeDown = false;
                            swipeUp = true;
                        }

                        else if (distance.y < -deadZone)
                        {
                            isMove = true;
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                            swipeRight = false;
                            swipeLeft = false;
                            swipeDown = true;
                            swipeUp = false;
                        }
                    }
                }
            }
        }
    }

    public void swipeMovement()
    {
        if (isMove == true)
        {
            if (swipeLeft)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

            if (swipeRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }

            if (swipeUp)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }

            if (swipeDown)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
        }
    }

    public void raycastMethod()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.30f, layer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            isMove = false;
            isCollision = true;
        }
        else
        {
            isCollision = false;
        }
    }
}
