using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Monster : MonoBehaviour
{
   public int MoveCount;
   public int MoveCount1;
    public Sprite[] sprites;

    float WeakEndTime;
    float DieEndTime;

    Vector2 Startvec;

    public bool HasDie;
   
    // Start is called before the first frame update
    void Start()
    {
        MoveCount = Random.Range(1, 5);
        WeakEndTime = 10;
        DieEndTime = 5;
        Startvec = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PacStudentController.Starttime > 0)
        {
            return;
        }
        if (PacStudentController.End)
        {
            return;
        }
        if (PacStudentController.GameType == 1)
        {
            MoveCount1 = 1;
            this.GetComponent<Animator>().SetInteger("State", 4);
        }
        if (MoveCount1 == 1)
        {
            WeakEndTime -= Time.deltaTime;
            if (WeakEndTime <= 0)
            {
                WeakEndTime = 10;
                PacStudentController.GameType = 0;
                this.GetComponent<Animator>().SetInteger("State", 0);
                EndWeak();
            }
        }
        if (MoveCount == 6)
        {
            DieEndTime -= Time.deltaTime;
            if (DieEndTime <= 0)
            {
              this.transform.position = Startvec;
                DieEndTime = 5;
                MoveCount = Random.Range(1, 5);
                this.GetComponent<Animator>().SetInteger("State", 4);
                HasDie = false;
            }
        }
        if (MoveCount == 1)
        {
           
            if (MoveCount1 == 1)
            {
                this.transform.Translate(Vector2.up * Time.deltaTime * 0.5f);
            }
            else
            {
                this.GetComponent<Animator>().SetInteger("State", 0);
                this.transform.Translate(Vector2.up * Time.deltaTime);
            }
           
        }
        if (MoveCount == 2)
        {
           
            if (MoveCount1 == 1)
            {
                this.transform.Translate(Vector2.down * Time.deltaTime * 0.5f);
            }
            else
            {
                this.GetComponent<Animator>().SetInteger("State", 1);
                this.transform.Translate(Vector2.down * Time.deltaTime);
            }

        }
        if (MoveCount == 3)
        {
           
            if (MoveCount1 == 1)
            {
                this.transform.Translate(Vector2.left * Time.deltaTime * 0.5f);
            }
            else
            {
                this.GetComponent<Animator>().SetInteger("State", 2);
                this.transform.Translate(Vector2.left * Time.deltaTime);
            }
        }
        if (MoveCount == 4)
        {
          
            if (MoveCount1 == 1)
            {
                this.transform.Translate(Vector2.right * Time.deltaTime * 0.5f);
            }
            else
            {
                this.GetComponent<Animator>().SetInteger("State", 3);
                this.transform.Translate(Vector2.right * Time.deltaTime);
            }
        }
       
    }
    public void EndWeak()
    {

        MoveCount1 = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (MoveCount == 1)
            {
                this.transform.position = this.transform.position - Vector3.up*Time.deltaTime*2;
            }
            if (MoveCount == 2)
            {
                this.transform.position = this.transform.position - Vector3.down * Time.deltaTime*2;
            }
            if (MoveCount == 3)
            {
                this.transform.position = this.transform.position - Vector3.left * Time.deltaTime*2;
            }
            if (MoveCount == 4)
            {
                this.transform.position = this.transform.position - Vector3.right * Time.deltaTime*2;
            }
            int temp = MoveCount;
            while (MoveCount == temp)
            {
                MoveCount = Random.Range(1, 5);
            }
        }
       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       
        int temp = MoveCount;
        while (MoveCount == temp)
        {
            MoveCount = Random.Range(1, 5);
        }
    }
}
