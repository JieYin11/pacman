using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PacStudentController : MonoBehaviour
{
    // Start is called before the first frame update
  
   

    public AudioClip[] audioClips;

    public int GameScore;
    public float GameScoreTime;
    public Text text;

    public static int GameType;
    private int hour;
    private int minute;
    private int second;
    public Text text2;

    public Text text3;
    float WeakTime;

    public bool Move { get; private set; }

    public Vector2[] vector2s = new Vector2[2];

    public int hp;
    public GameObject[] HPImg;
    public Text text5;
    public static float Starttime;

    public GameObject EndImg;
    public int AllCount;
    public static bool End;
    float EndTime;

    public GameObject AllWall;
    public GameObject ShowPar;
    public GameObject ShowPar1;
    public GameObject ShowPar2;
    void Start()
    {
        End = false;
        Time.timeScale = 1;
        hp = 3;
        Starttime = 4;
        vector2s[0] = new Vector2(1, 1);
        vector2s[1] = new Vector2(1, 1);
        GameType = 0;
      
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Starttime > 0)
        {
            Starttime -= Time.deltaTime;
            if (Starttime >= 0)
            {
                text5.text = "GO";
            }
            if (Starttime >= 1)
            {
                text5.text = "1";
            }
            if (Starttime >= 2)
            {
                text5.text = "2";
            }
            if (Starttime >= 3)
            {
                text5.text = "3";
            }
            return;
        }
        else
        {
            text5.gameObject.SetActive(false);
        }
        if (End)
        {
            EndTime += Time.deltaTime;
            if (EndTime >= 3)
            {
                SceneManager.LoadScene(0);
            }
        }
        if (AllCount >= 55 * 4)
        {
            EndImg.SetActive(true);
            End = true;
            if (StartScene.BestGameScore < GameScore)
            {
                StartScene.BestGameScore = GameScore;
            }
            if (StartScene.BestTime > GameScoreTime)
            {
                StartScene.BestTime = GameScoreTime;
            }         
            return;

        }
        for (int i = 0; i < 3; i++)
        {
            if (i < hp)
            {
                HPImg[i].SetActive(true);
            }
            else
            {
                HPImg[i].SetActive(false);
            }
        }
        if (hp <= 0)
        {
            End = true;
            EndImg.SetActive(true);

            if (StartScene.BestGameScore < GameScore)
            {
                StartScene.BestGameScore = GameScore;
            }
            return;
        }
      
          
        
      

        GameScoreTime += Time.deltaTime;
        hour = (int)GameScoreTime / 3600;
        minute = ((int)GameScoreTime - hour * 3600) / 60;
        second = (int)GameScoreTime - hour * 3600 - minute * 60;
        text2.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
        if (WeakTime > 0)
        {
            text3.gameObject.SetActive(true);
            WeakTime -= Time.deltaTime;
            text3.text = ((int)WeakTime).ToString();
        }
        else
        {
            text3.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        MyMove();
        text.text = GameScore.ToString();
      

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "1")
        {
            GameScore += 1;
            AllCount += 1;
            this.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "2")
        {
            GameScore += 1;
            GameType = 1;
            WeakTime = 10;
            this.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "3")
        {
            GameScore += 100;
            this.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
            Destroy(collision.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "3")
        {
            // GameScore += 1;
            this.GetComponent<AudioSource>().PlayOneShot(audioClips[2]);
            //  Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "5")
        {
            if (collision.gameObject.GetComponent<Monster>().MoveCount1 == 1 && collision.gameObject.GetComponent<Monster>().MoveCount != 6)
            {
                collision.gameObject.GetComponent<Monster>().MoveCount = 6;
                GameScore += 300;
                this.GetComponent<AudioSource>().PlayOneShot(audioClips[1]);
                collision.gameObject.GetComponent<Animator>().SetInteger("State", 4);
                collision.gameObject.GetComponent<Monster>().HasDie = true;
            }
            else
            {
                hp -= 1;
                GameObject gameObjectitem = GameObject.Instantiate(ShowPar2);
                gameObjectitem.transform.position = this.transform.position;
                vector2s[0] = new Vector2(1, 1);
                vector2s[1] = new Vector2(1, 1);
                this.transform.position = new Vector3(-26.63f + 1 * 0.64f, 12.18f - 1 * 0.64f, 0);
                this.GetComponent<AudioSource>().PlayOneShot(audioClips[3]);

            }
        }
    }
    public void MyMove()
    {
        ShowPar.SetActive(true);
        if (Input.GetKeyDown(KeyCode.A) && !Move)
        {
            if (vector2s[1].x == 14 && vector2s[1].y == 1)
            {
                Debug.Log("2");
                vector2s[1] = new Vector2(14, 26);
                this.transform.position = new Vector3(-14f + vector2s[1].y * 0.64f, 17f - vector2s[1].x * 0.64f, 0);
                vector2s[0] = vector2s[1];
                return;
            }
            bool MoveThis=false;
            for (int i = 0; i < AllWall.transform.childCount; i++)
            {
                if (AllWall.transform.GetChild(i).transform.position == new Vector3(-14f + (vector2s[0].y - 1) * 0.64f, 17f - (vector2s[0].x) * 0.64f, 0))
                {
                    MoveThis = true;
                }
            }
          
            if (!MoveThis)
            {
                vector2s[1] = new Vector2((int)vector2s[0].x, (int)vector2s[0].y - 1);
                ShowPar.transform.localEulerAngles = new Vector3(0, 0, 0);
                Move = true;
                this.GetComponent<Animator>().SetInteger("State", 1);

                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClips[2]);
                ShowPar1.SetActive(true);
                Debug.Log("1");
            }

        }
        if (Input.GetKeyDown(KeyCode.D) && !Move)
        {

            if (vector2s[1].x == 14 && vector2s[1].y == 26)
            {
                vector2s[1] = new Vector2(14, 1);
                this.transform.position = new Vector3(-14f + vector2s[1].y * 0.64f, 17f - vector2s[1].x * 0.64f, 0);
                vector2s[0] = vector2s[1];
                return;
            }
            bool MoveThis = false;
            for (int i = 0; i < AllWall.transform.childCount; i++)
            {
                if (AllWall.transform.GetChild(i).transform.position == new Vector3(-14f + (vector2s[0].y + 1) * 0.64f, 17f - (vector2s[0].x) * 0.64f, 0))
                {
                    MoveThis = true;
                }
            }
            if (!MoveThis)
            {
                vector2s[1] = new Vector2((int)vector2s[0].x, (int)vector2s[0].y + 1);
                Move = true;
                // this.transform.localEulerAngles = new Vector3(0, 0, -90);
                ShowPar.transform.localEulerAngles = new Vector3(0, 0, 180);

                this.GetComponent<Animator>().SetInteger("State", 0);
                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClips[2]);
                ShowPar1.SetActive(true);
            }

        }
        if (Input.GetKeyDown(KeyCode.W) && !Move)
        {

            bool MoveThis = false;
            for (int i = 0; i < AllWall.transform.childCount; i++)
            {
                if (AllWall.transform.GetChild(i).transform.position == new Vector3(-14f + (vector2s[0].y ) * 0.64f, 17f - (vector2s[0].x-1) * 0.64f, 0))
                {
                    MoveThis = true;
                }
            }
            if (!MoveThis)
            {
                vector2s[1] = new Vector2((int)vector2s[0].x - 1, (int)vector2s[0].y);
                Move = true;
                this.GetComponent<Animator>().SetInteger("State", 2);

                ShowPar.transform.localEulerAngles = new Vector3(0, 0, -90);
                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClips[2]);
                ShowPar1.SetActive(true);
            }

        }
        if (Input.GetKeyDown(KeyCode.S) && !Move)
        {

            bool MoveThis = false;
            for (int i = 0; i < AllWall.transform.childCount; i++)
            {
                if (AllWall.transform.GetChild(i).transform.position == new Vector3(-14f + (vector2s[0].y) * 0.64f, 17f - (vector2s[0].x + 1) * 0.64f, 0))
                {
                    MoveThis = true;
                }
            }
            if (!MoveThis)
            {
                vector2s[1] = new Vector2((int)vector2s[0].x + 1, (int)vector2s[0].y);
                Move = true;
                ShowPar.transform.localEulerAngles = new Vector3(0, 0, 90);
                this.GetComponent<Animator>().SetInteger("State", 3);

                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClips[2]);
                ShowPar1.SetActive(true);
            }

        }

        Vector3 vector3temp = new Vector3(-14f + vector2s[1].y * 0.64f, 17f - vector2s[1].x * 0.64f, 0);
        this.transform.position = Vector2.Lerp(this.transform.position, vector3temp, Time.deltaTime * 3);

        if (Vector2.Distance(this.transform.position, vector3temp) <= 0.05f)
        {
            this.GetComponent<AudioSource>().Pause();
            vector2s[0] = vector2s[1];
            Move = false;
            ShowPar.SetActive(false);

        }

    }
    public void ZhuYe()
    {
        SceneManager.LoadScene(0);
    }
}
