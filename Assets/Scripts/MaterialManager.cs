using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public static MaterialManager Instance = null;

    [SerializeField] public Material playerMat;
    [SerializeField] public Material enemyMat;

    private void Awake()
    {
        Application.targetFrameRate = 100;
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }


    public Material GetMat(CharacterType c)
    {
        switch (c)
        {
            case CharacterType.Enemy:
                return enemyMat;

            case CharacterType.Player:
                return playerMat;
                    
        }

        return playerMat;
    }
}
