using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Attriubtes")]
    [SerializeField] float scaleUp;
    [SerializeField] int strength;
    [SerializeField] float origY;

    [Header("Component References")]
    [SerializeField] Material playerMat;
    [SerializeField] Material enemyMat;


    private void Start()
    {
       
    }

   public void AddCharacter(CharacterType t)
    {
        if (t == CharacterType.Player)
        {
            strength++;
        }
        if (t == CharacterType.Enemy)
        {
            strength--;
        }
        if (strength > 0)
        {
            GetComponent<MeshRenderer>().material = playerMat;
        }
        if (strength < 0)
        {
            GetComponent<MeshRenderer>().material = enemyMat;
        }
     
      //  transform.localScale= new Vector3(transform.localScale.x, transform.localScale.y )
    }
}
