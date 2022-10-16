using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Attribues")]
    [SerializeField] float moveSpeed;
    [SerializeField] bool canMove;
    [SerializeField] Vector3 moveVector;
    [SerializeField] public CharacterType type;
    [SerializeField] public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        //rb.AddForce(moveVector * moveSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.Translate(moveVector * moveSpeed * Time.deltaTime);
            //GetComponent<CharacterController>().Move(moveVector * moveSpeed * Time.deltaTime);
        }
    }
}
