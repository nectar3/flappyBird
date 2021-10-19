using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    PipePair parentScript;

    private void Start()
    {
        parentScript = transform.parent.GetComponent<PipePair>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            parentScript.PlayerCollide();
        }
    }


}
