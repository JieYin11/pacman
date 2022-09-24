using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoShow : MonoBehaviour
{
    public float Time1;
    float Time2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time2 += Time.deltaTime;
        if (Time2 >= Time1)
        {
            Time2 = 0;
            this.gameObject.SetActive(false);
        }
    }
}
