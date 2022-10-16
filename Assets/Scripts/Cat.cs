using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] SpriteRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            //Trigger GameOver
            //VFX
            //Cat Sad
            mr.color = Color.red;
            GameManager.Instance.LoseLevel();
        }
    }
}
