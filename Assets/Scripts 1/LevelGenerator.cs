using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Sprite[] Thissprites;
    public GameObject[] gameMap;
    int[,] ThisMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {1,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {2,0,0,0,0,0,5,0,0,0,4,0,0,0},             
    };
   public static  int[,] ThisMap4 = new int[29, 28];
    // Start is called before the first frame update
    void Start()
    {
        int[,] ThisMap1=new int[14,14];
        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                ThisMap1[i,j] = ThisMap[13 - i,j];
            }
        }
        int[,] ThisMap2 = new int[29, 14];
        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                if (i < 15)
                    ThisMap2[i, j] = ThisMap[i, j];
                else
                {
                    ThisMap2[i, j] = ThisMap1[i-15, j];
                }
            }
        }
        int[,] ThisMap3 = new int[29, 14];
        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                ThisMap3[i, j] = ThisMap2[i, 13-j];
            }
        }
       

        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j < 28; j++)
            {
                if (j < 14)
                    ThisMap4[i, j] = ThisMap2[i, j];
                else
                {
                    ThisMap4[i, j] = ThisMap3[i , j-14];
                }
            }
        }
        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j < 28; j++)
            {
                bool BTrue = false;

                if (ThisMap4[i, j] == 0)
                {

                }
                else
                {
                    GameObject gameObject1 = GameObject.Instantiate(gameMap[ThisMap4[i, j] - 1]);
                    //gameObject1.GetComponent<SpriteRenderer>().sprite = Thissprites[ThisMap4[i, j] - 1];

                   
                    gameObject1.transform.position = new Vector3(-14  + j * 0.64f, 17 - i * 0.64f, 0);
                    if (ThisMap4[i, j] == 1)
                    {
                        if (i - 1 >= 0)
                        {
                            if (ThisMap4[i - 1, j] == 2 || ThisMap4[i - 1, j] == 1)
                            {
                                if (j - 1 >= 0)
                                {
                                    if (ThisMap4[i, j - 1] == 2 || ThisMap4[i, j - 1] == 1)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);

                                    }
                                }
                                if (j + 1 <= 27)
                                {
                                    if (ThisMap4[i, j + 1] == 2 || ThisMap4[i, j + 1] == 1)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);

                                    }
                                }


                            }
                        }
                        if (i + 1 <= 28)
                        {
                            if (ThisMap4[i + 1, j] == 2 || ThisMap4[i + 1, j] == 1)
                            {
                                if (j - 1 >= 0)
                                {
                                    if (ThisMap4[i, j - 1] == 2 || ThisMap4[i, j - 1] == 1)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);

                                    }
                                }
                                if (j + 1 <= 27)
                                {
                                    if (ThisMap4[i, j + 1] == 2 || ThisMap4[i, j + 1] == 1)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);

                                    }
                                }

                            }
                        }
                      
                    }
                    if (ThisMap4[i, j] == 2)
                    {
                        if (i - 1 >= 0)
                        {
                            if (ThisMap4[i - 1, j] == 2 || ThisMap4[i - 1, j] == 1 || ThisMap4[i - 1, j] == 7)
                            {

                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);




                            }
                        }
                        if (j - 1 >= 0)
                        {
                            if (ThisMap4[i, j - 1] == 2 || ThisMap4[i, j - 1] == 1 || ThisMap4[i, j - 1] == 7)
                            {

                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);




                            }
                        }
                        gameObject1.transform.localEulerAngles = gameObject1.transform.localEulerAngles + new Vector3(0, 0, 90);
                    }
                    if (ThisMap4[i, j] == 3)
                    {
                        if (i - 1 >= 0)
                        {
                            if (ThisMap4[i - 1, j] == 4 || ThisMap4[i - 1, j] == 3)
                            {
                                if (j - 1 >= 0)
                                {
                                    if (ThisMap4[i, j - 1] == 4 || ThisMap4[i, j - 1] == 3)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);
                                        if (ThisMap4[i - 1, j] == 4 && ThisMap4[i, j - 1] == 4)
                                        {
                                            BTrue = true;
                                        }
                                    }
                                }
                                if (j + 1 <= 27)
                                {
                                    if (ThisMap4[i, j + 1] == 4 || ThisMap4[i, j + 1] == 3)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                                        if (ThisMap4[i - 1, j] == 4 && ThisMap4[i, j + 1] == 4)
                                        {
                                            BTrue = true;
                                        }

                                    }
                                }



                            }
                        }
                        if (j + 1 <= 27 && j - 1 >= 0 && i - 1 >= 0 && i + 1 <= 28)
                        {
                            if (ThisMap4[i - 1, j] == 4 || ThisMap4[i - 1, j] == 3)
                            {
                                if (ThisMap4[i + 1, j] == 4 || ThisMap4[i + 1, j] == 3)
                                {
                                    if (ThisMap4[i, j - 1] == 4 || ThisMap4[i, j - 1] == 3)
                                    {
                                        if (ThisMap4[i, j + 1] == 4 || ThisMap4[i, j + 1] == 3)
                                        {
                                            if (ThisMap4[i - 1, j] == 4 && ThisMap4[i, j - 1] == 4)
                                            {
                                                if (ThisMap4[i - 2, j] == 4 && ThisMap4[i, j - 2] == 4)
                                                {
                                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);
                                                    BTrue = true;
                                                }
                                            }
                                            if (ThisMap4[i - 1, j] == 4 && ThisMap4[i, j + 1] == 4)
                                            {
                                                if (ThisMap4[i - 2, j] == 4 && ThisMap4[i, j + 2] == 4)
                                                {
                                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                                                    BTrue = true;
                                                }
                                            }
                                            if (ThisMap4[i + 1, j] == 4 && ThisMap4[i, j + 1] == 4)
                                            {
                                                if (ThisMap4[i + 2, j] == 4 && ThisMap4[i, j + 2] == 4)
                                                {
                                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                                                    BTrue = true;
                                                }
                                            }
                                            if (ThisMap4[i + 1, j] == 4 && ThisMap4[i, j - 1] == 4)
                                            {
                                                if (ThisMap4[i + 2, j] == 4 && ThisMap4[i, j - 2] == 4)
                                                {
                                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);
                                                    BTrue = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (i + 1 <= 28 && !BTrue)
                        {
                            if (ThisMap4[i + 1, j] == 4 || ThisMap4[i + 1, j] == 3)
                            {
                                if (j - 1 >= 0)
                                {
                                    if (ThisMap4[i, j - 1] == 4 || ThisMap4[i, j - 1] == 3)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);

                                    }
                                }
                                if (j + 1 <= 27)
                                {
                                    if (ThisMap4[i, j + 1] == 4 || ThisMap4[i, j + 1] == 3)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);

                                    }
                                }

                            }
                        }
                     

                    }
                    if (ThisMap4[i, j] == 4)
                    {
                        if (i - 1 >= 0)
                        {
                            if (ThisMap4[i - 1, j] == 3 || ThisMap4[i - 1, j] == 4 || ThisMap4[i - 1, j] == 7)
                            {
                                if (i + 1 <= 28)
                                {
                                    if (ThisMap4[i + 1, j] == 3 || ThisMap4[i + 1, j] == 4 || ThisMap4[i + 1, j] == 7)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                                    }
                                }



                            }
                        }
                        if (j - 1 >= 0)
                        {
                            if (ThisMap4[i, j - 1] == 3 || ThisMap4[i, j - 1] == 4 || ThisMap4[i, j - 1] == 7)
                            {
                                if (j + 1 <= 27)
                                {
                                    if (ThisMap4[i, j + 1] == 4 || ThisMap4[i, j + 1] == 3 || ThisMap4[i, j + 1] == 7)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                                    }
                                }



                            }
                        }
                        gameObject1.transform.localEulerAngles = gameObject1.transform.localEulerAngles + new Vector3(0, 0, 90);
                    }
                    if (ThisMap4[i, j] == 7)
                    {
                        if (i - 1 >= 0)
                        {
                            if (ThisMap4[i - 1, j] == 3 || ThisMap4[i - 1, j] == 4)
                            {
                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);
                            }
                        }
                        if (i + 1 <= 27)
                        {
                            if (ThisMap4[i + 1, j] == 3 || ThisMap4[i + 1, j] == 4)
                            {
                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            if (ThisMap4[i, j - 1] == 3 || ThisMap4[i, j - 1] == 4)
                            {
                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);
                            }
                        }
                        if (j + 1 <= 27)
                        {
                            if (ThisMap4[i, j + 1] == 3 || ThisMap4[i, j + 1] == 4)
                            {
                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                            }
                        }

                    }
                }
            }
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
