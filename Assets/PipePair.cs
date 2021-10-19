using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePair : MonoBehaviour
{

    public float speed;

    Transform upper;
    Transform lower;

    float sceneHeight = 5f;

    float pipe_length;

    private void Start()
    {
        upper = transform.GetChild(0);
        lower = transform.GetChild(1);

        pipe_length = lower.GetComponent<SpriteRenderer>().bounds.size.y;

        SetPipePosition();
    }

    public void PlayerCollide()
    {
        Time.timeScale = 0;
        Debug.Log("died");
    }

    public void PlayerPass()
    {
        SoundManager.Instance.PlayPointSound();
        GameManager.Instance.AddPoint();
    }

    void SetPipePosition()
    {

        var holeY = Random.Range(-sceneHeight * 0.8f, sceneHeight * 0.8f);
        var gap = Random.Range(2, 6);

        var upperY = holeY + (gap / (float)2) + pipe_length / 2;
        var lowerY = holeY - (gap / (float)2) - pipe_length / 2;

        upper.localPosition = new Vector2(0, upperY);
        lower.localPosition = new Vector2(0, lowerY);

        //Debug.Log("holeY: " + holeY);
        //Debug.Log("gap: " + gap);
        //Debug.Log("lower: " + lower.localPosition);
        //Debug.Log("upper: " + upper.localPosition);
    }


    void Update()
    {
        transform.position = new Vector2(transform.position.x + -(speed * Time.deltaTime), transform.position.y);

        if (transform.position.x < -5)
            Destroy(gameObject);
    }



}
