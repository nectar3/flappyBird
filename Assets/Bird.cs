using UnityEngine;

public class Bird : MonoBehaviour
{
    public float Power = 5f;

    Rigidbody2D rigid;

    float maxAngle = 60f;
    float minAngle = -60f;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        rigid.AddForce(Vector2.up * Power, ForceMode2D.Impulse);

    }

    int count = 0;
    private void Update()
    {
        if (Time.timeScale == 0)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rigid.AddForce(Vector2.up * Power, ForceMode2D.Impulse);
            rigid.velocity = Vector2.up * Power;
        }

        FaceDirection();

        //if (count++ % 20 == 1)
        //    Debug.Log(rigid.velocity.y);
    }


    void FaceDirection()
    {

        var vel = rigid.velocity.y;
        var angle = (vel >= 0) ? Mathf.Lerp(0, maxAngle, vel / 5) : Mathf.Lerp(0, minAngle, Mathf.Abs(vel) / 5);

        transform.rotation = Quaternion.Euler(0, 0, angle);



    }



}
