using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject cam;
    private  bool close;
    [SerializeField] private float parallaxEffect;
    [SerializeField] private bool isSkyBG;

    private float xPosition;
    private float yPosition;
    private float length;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        xPosition = transform.position.x;
        yPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (close)
            return;
        float xDistanceToMove = cam.transform.position.x * parallaxEffect;
        float xDistanceMoved = cam.transform.position.x * (1 - parallaxEffect);

        float yDistanceToMove = cam.transform.position.y * parallaxEffect;
        float yDistanceMoved = cam.transform.position.y* (1 - parallaxEffect);

        transform.position = new Vector3(xPosition + xDistanceToMove, transform.position.y);
        if (xDistanceMoved > xPosition + length)
        {
            xPosition = xPosition + length;
        }
        else if(xDistanceMoved < xPosition - length)
        {
            xPosition = xPosition - length;
        }

        if (isSkyBG)
        {
            if (yDistanceMoved > yPosition + length)
            {
                yPosition = yPosition + length;
            }
            else if (yDistanceMoved < yPosition - length)
            {
                yPosition = yPosition - length;
            }
            transform.position = new Vector3(transform.position.x, yPosition + yDistanceToMove);
        }

    }


    public void OpenBGParallax()
    {
        close = false;
    }
    public void CloseBGParallax() => close = true;
}
