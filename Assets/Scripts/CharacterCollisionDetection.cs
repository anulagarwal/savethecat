using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionDetection : MonoBehaviour
{
    [SerializeField] CharacterType c;

    private void Start()
    {
        c = GetComponent<Character>().type;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Step")
        {
            if (other.gameObject.GetComponent<Step>().type != c)
            {
                other.gameObject.GetComponent<Step>().type = c;
                other.gameObject.GetComponent<MeshRenderer>().material = MaterialManager.Instance.GetMat(c);
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyBase")
        {
            collision.gameObject.GetComponent<EnemyBase>().ReduceHealth(1);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Tower")
        {
           // collision.gameObject.GetComponent<Tower>().AddCharacter(c);
           // Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Step")
        {
            if (collision.gameObject.GetComponent<Step>().type != c)
            {
                collision.gameObject.GetComponent<Step>().type = c;
                collision.gameObject.GetComponent<MeshRenderer>().material = MaterialManager.Instance.GetMat(c);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
