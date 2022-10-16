using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyBase : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] int health;

    [Header("Component References")]
    [SerializeField] TextMeshPro tm;


    private void OnDisable()
    {
        tm.text = "";
        GetComponent<Spawner>().enabled = false;

    }
    private void OnEnable()
    {
        tm.text = "" + health;
        GetComponent<Spawner>().enabled = true;

    }
    // Start is called before the first frame update
    void Start()
    {
        tm.text = "" + health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth(int v)
    {
        if(health>0)
        health -= v;

        tm.text = "" + health;

        if (health <= 0)
        {
            GameManager.Instance.WinLevel();            
        }

    }
}
