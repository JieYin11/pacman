using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplayer : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2[] ThisVec;

    public int ThisCount;

    public Vector2 Thisone;
    void Start()
    {
        ThisCount = 1;
        Thisone = ThisVec[ThisCount];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector3temp = new Vector3(-14f + Thisone.y * 0.64f, 17f - Thisone.x * 0.64f, 0);
        this.transform.position = Vector2.Lerp(this.transform.position, vector3temp, Time.deltaTime * 3);
        if (Vector2.Distance(this.transform.position, vector3temp) <= 0.05f)
        {

            ThisCount += 1;
            if (ThisCount >= 4)
            {
                ThisCount = 0;
            }
            Thisone = ThisVec[ThisCount];
            if (ThisCount == 1)
            {
                this.transform.localEulerAngles = new Vector3(0, 0, 0);
                this.GetComponent<Animator>().SetInteger("State", 0);
            }
            if (ThisCount == 2)
            {
                this.transform.localEulerAngles = new Vector3(0, 0, -90);
                this.GetComponent<Animator>().SetInteger("State", 3);
            }
            if (ThisCount == 3)
            {
                this.transform.localEulerAngles = new Vector3(0, 180, 0);
                this.GetComponent<Animator>().SetInteger("State", 1);
            }
            if (ThisCount == 0)
            {
                this.transform.localEulerAngles = new Vector3(0, 0, 90);
                this.GetComponent<Animator>().SetInteger("State", 2);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "4")
        {
            Destroy(collision.gameObject);
            this.GetComponent<AudioSource>().Play();
            
        }
    }
    
}
