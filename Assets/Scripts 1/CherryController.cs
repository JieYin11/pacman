using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    float GameTimeCreate;
    public GameObject gameObject1;
    // Start is called before the first frame update
    void Start()
    {
        GameTimeCreate =10;
    }

    // Update is called once per frame
    void Update()
    {
        GameTimeCreate -= Time.deltaTime;
        if (GameTimeCreate <= 0)
        {
            GameTimeCreate = 10;
            GameObject gameObject2 = GameObject.Instantiate(gameObject1);
            gameObject2.transform.position = new Vector3(7f, Random.Range(2.36f,14.0f), 0);
        }
    }
}
