using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] float checkDuration;
    [SerializeField] Vector2 prevLoc;
    [SerializeField] public bool isMoving;

    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
        prevLoc = transform.position;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if(startTime + checkDuration < Time.time)
            {
                startTime = Time.time;
                if(Vector2.Distance(transform.position, prevLoc) < Controller.Instance.waterMoveDistance)
                {
                    isMoving = false;
                }
                else
                {
                    prevLoc = transform.position;
                }
            }
        }
    }
}
