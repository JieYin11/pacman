using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartScene : MonoBehaviour
{
    public static float BestTime;
    public static int BestGameScore;

    public Text[] texts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        texts[0].text = BestTime.ToString("f3");
        texts[1].text = BestGameScore.ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void StartGame1()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
