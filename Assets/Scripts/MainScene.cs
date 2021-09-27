using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{

    public GameObject a;

    void Start()
    {
        //transform.gameObject.
        for (int i = 0; i < 10;  i ++)
        {
            GameObject b = Instantiate(a);
            b.transform.parent = gameObject.transform;

            b.transform.position = new Vector3((i - 4) * 2, (i - 4) * 2, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
