using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] float spawnSpeed;
    [SerializeField] bool canSlide;
    [SerializeField] float slideSpeed;
    [SerializeField] float spawnRate;

    private float startTime;

    [Header("Component References")]
    [SerializeField] GameObject character;
    [SerializeField] Transform ShooterPos;
    [SerializeField] Transform canon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnCharacter();
            startTime = Time.time;
        }

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                canon.position = new Vector3(hit.point.x, canon.position.y, canon.position.z);
            }

                if (startTime + spawnRate < Time.time)
            {
                SpawnCharacter();
                startTime = Time.time;                
            }
           
        }

        if (Input.GetMouseButtonUp(0))
        {

        }
    }

    void SpawnCharacter()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            GameObject g = Instantiate(character, ShooterPos.position, Quaternion.identity);
        }
    }
}
