using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShooter : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] Vector2 forceDir;
    [SerializeField] float force;
    [SerializeField] float spawnRate;
    [SerializeField] int maxDrops;
    [SerializeField] float duration;

    bool isShooting = false;
    bool isChecking = false;

    [Header("Component References")]
    [SerializeField] GameObject water;
    [SerializeField] Transform shootPos;

    List<GameObject> waterDrops = new List<GameObject>();

    private float startTime;
    private float realStartTime;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startTime = Time.time;

        }

      
        if (Input.GetKey(KeyCode.Space))
        {          
            if (startTime + spawnRate < Time.time)
            {
                Shoot();
                startTime = Time.time;
            }
        }

        if (isShooting)
        {
            if(realStartTime + duration > Time.time)
            {
                if (startTime + spawnRate < Time.time)
                {
                    Shoot();
                    startTime = Time.time;
                }
            }
            else
            {
                isShooting = false;
                isChecking = true;
            }
        }

        if (isChecking)
        {
            bool isMoving = true;
            foreach(GameObject g in waterDrops)
            {
                isMoving = g.GetComponent<Water>().isMoving;                               
            }
            if (!isMoving)
            {
                GameManager.Instance.WinLevel();
            }
        }
    }

    void Shoot()
    {
        for(int i = 0; i< maxDrops; i++)
        {
            GameObject g = Instantiate(water, shootPos.position, Quaternion.identity);
            g.GetComponent<Rigidbody2D>().AddRelativeForce(-transform.right * force, ForceMode2D.Impulse);
            waterDrops.Add(g);
        }
       
    }

    public void BeginShoot()
    {
        isShooting = true;
        realStartTime = Time.time;
        startTime = Time.time;
    }
}
