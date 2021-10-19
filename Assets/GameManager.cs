using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public Transform SpawnPoint;

    public Transform pipePrefab;

    public TextMeshProUGUI textmesh;

    int point = 0;

    private static GameManager instance = null;
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
                return null;
            return instance;
        }

    }
    void Start()
    {
        textmesh.SetText("0");
        StartCoroutine(SpawnRoutine());
    }

    public void AddPoint()
    {
        point++;
        textmesh.SetText(point.ToString());
    }


    IEnumerator SpawnRoutine()
    {
        Instantiate(pipePrefab, SpawnPoint.position, Quaternion.identity);

        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            Instantiate(pipePrefab, SpawnPoint.position, Quaternion.identity);
        }



    }


}
