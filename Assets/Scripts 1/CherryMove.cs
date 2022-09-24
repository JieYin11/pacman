using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.left * Time.deltaTime * 2);
        if (this.transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }
    }
}
