using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxBG : MonoBehaviour
{
    public  Camera cameras;
    [SerializeField] private float parallexEffects;
    private float xPosition;
    private float Length;
    void Start()
    {
        xPosition = transform.position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;
        xPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = cameras.transform.position.x * (1 - parallexEffects);
        float distancetomove = cameras.transform.position.x * parallexEffects;
        transform.position = new Vector3(xPosition + distancetomove, transform.position.y);
        if (distanceMoved > xPosition + Length)
            xPosition = xPosition + Length;
        else if (distanceMoved < xPosition - Length)
            xPosition = xPosition - Length;
    }
}
