using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterShooter : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] Vector2 forceDir;
    [SerializeField] float force;
    [SerializeField] float spawnRate;
    [SerializeField] int maxDrops;
    [SerializeField] float duration;
    [SerializeField] string shootAnimation = "Shoot";

    bool isShooting = false;
    bool isChecking = false;

    [Header("Component References")]
    [SerializeField] GameObject water;
    [SerializeField] Transform shootPos;
    [SerializeField] Animator animator;
    [SerializeField] Image fillBar;
    [SerializeField] GameObject bar;

    [SerializeField] AudioSource waterSource;



    List<GameObject> waterDrops = new List<GameObject>();

    private float startTime;
    private float realStartTime;
   

    // Start is called before the first frame update
    void Start()
    {

        bar.SetActive(false);

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
                animator.Play("IdleFace");
                isShooting = false;
                isChecking = true;
                fillBar.fillAmount = 0;
                waterSource.Stop();
                bar.SetActive(false);

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
    private void OnDisable()
    {
                animator.Play("IdleFace");
        waterSource.Stop();
        bar.SetActive(false);

    }
    void Shoot()
    {
        for(int i = 0; i< maxDrops; i++)
        {
            GameObject g = Instantiate(water, shootPos.position, Quaternion.identity);
            g.GetComponent<Rigidbody2D>().AddRelativeForce(shootPos.transform.right * force, ForceMode2D.Impulse);
            waterDrops.Add(g);
        }
        fillBar.fillAmount = 1 - ((Time.time - realStartTime)/duration);
    }

    public void BeginShoot()
    {
        bar.SetActive(true);
        isShooting = true;
        realStartTime = Time.time;
        startTime = Time.time;
        animator.Play(shootAnimation);
        waterSource.Play();

    }
}
