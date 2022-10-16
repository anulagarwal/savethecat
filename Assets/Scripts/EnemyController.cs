using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] float slideSpeed;
    [SerializeField] float spawnRate;
    [SerializeField] bool isPressed;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [SerializeField] float targetX;

    [SerializeField] bool isMoving;
    [SerializeField] int moveDir;
    bool right;
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
        if (isMoving)
        {            
           canon.position = new Vector3(Mathf.Lerp(canon.position.x, targetX, slideSpeed), canon.position.y, canon.position.z);
            if(Mathf.Abs(canon.position.x- targetX) < 0.1f)
            {
                ChangeDir(!right);
            }
        }

        if (isPressed)
        {
            SpawnCharacter();

            if (startTime + spawnRate < Time.time)
            {
                startTime = Time.time;
            }
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

    void ChangeDir(bool b)
    {
        right = b;
        if (b)
        {
            targetX = maxX;
        }
        else if (!b)
        {
            targetX = minX;
        }
    }
}
