using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller Instance = null;

    [Header("Attributes")]
    [SerializeField] public float waterMoveDistance;

    [Header("Component References")]
    [SerializeField] List<WaterShooter> ws;
    [SerializeField] Rigidbody2D cat;
    [SerializeField] GameObject check;
    [SerializeField] GameObject cross;
    [SerializeField] GameObject protectText;





    private void Awake()
    {
        Application.targetFrameRate = 100;
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        cat.isKinematic = true;
    }

    public void FinishDrawing()
    {
        foreach (WaterShooter w in ws)
        {
            w.BeginShoot();
        }
        cat.isKinematic = false;
    }
    public void DisableProtectText()
    {
        protectText.SetActive(false);
    }

    public void ShowFinal(bool win)
    {
        if (win)
        {
            check.SetActive(true);
            check.transform.position = cat.transform.position;

        }
        if (!win)
        {
            cross.SetActive(true);
            cross.transform.position = cat.transform.position;
        }
    }
}
