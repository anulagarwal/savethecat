using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] GameObject character;
    [SerializeField] Transform spawnPos;


    [Header("Attributes")]
    [SerializeField] float interval;
    [SerializeField] float randomRadius;
    [SerializeField] int number;
    [SerializeField] int maxDrops;

    int currentDrops;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator StartSpawn()
    {
        while (currentDrops < maxDrops)
        {
            for (int i = 0; i < number; i++)
            {
                Spawn(spawnPos.position);
            }

            yield return new WaitForSeconds(interval);
        }
    }

    public void Spawn(Vector3 pos)
    {
        GameObject g= Instantiate(character, pos, Quaternion.identity);
        currentDrops++;
    }
}
