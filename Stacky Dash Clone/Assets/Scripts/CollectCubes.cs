using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectCubes : MonoBehaviour
{
    ScoreManager scoreManager;
    public ParticleSystem particle;

    public GameObject stackParent;
    public GameObject player, player2;

    Vector3 stackPos;

    public List<GameObject> stack = new List<GameObject> ();

    public static bool isPathActive, isPathActive2, isPathActive3;
    bool isPathActive3Touched;

    // Start is called before the first frame update
    void Start()
    {
        stackPos = new Vector3(0, 1.57f, 0);
        isPathActive = false;
        isPathActive2 = false;
        isPathActive3 = false;
        scoreManager = GetComponent<ScoreManager> ();;
        isPathActive3Touched = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int childCountNumber = stackParent.transform.childCount;

        if (other.CompareTag("Cube"))
        {
            stackPos += new Vector3(0, 1.1f, 0);
            other.gameObject.transform.parent = stackParent.transform;
            stack.Add(other.gameObject);
            other.transform.DOLocalMove(stackPos, 0);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.GetChild(1).transform.localPosition += new Vector3(0, 1.1f, 0);
            scoreManager.increasePoint();
        }

        if (other.CompareTag("PathWallActive"))
        {
            isPathActive = true;
        }

        if (other.CompareTag("PathWallDisactive"))
        {
            isPathActive = false;
        }

        if (other.CompareTag("PathWallActive2"))
        {
            isPathActive2 = true;    
        }

        if (other.CompareTag("PathWallDisactive2"))
        {
            isPathActive2 = false;
        }

        if (other.CompareTag("PathWallActive3"))
        {
            isPathActive3 = true;
            isPathActive3Touched = true;
            scoreManager.showScoreText();
        }

        if (other.CompareTag("PathWallDisactive3"))
        {
            isPathActive3 = false;
            scoreManager.showRestartButton();
            PlayerMovement.isGameActive = false;
            particle.Play();
            
            player.SetActive(false);
            player2.SetActive(true);
            
        }

        if (other.CompareTag("Dropped"))
        {
            stackPos -= new Vector3(0, 1.1f, 0);
            Destroy(stackParent.transform.GetChild(childCountNumber - 1).gameObject);
            stack.RemoveAt(stack.Count - 1);
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(1).transform.localPosition -= new Vector3(0, 1.1f, 0);
        }
    }
}
