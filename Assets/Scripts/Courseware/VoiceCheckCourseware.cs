using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceCheckCourseware : MonoBehaviour
{


    [SerializeField]
    Vector2[] flatPosition;

    [SerializeField]
    GameObject itemPre;
    // Start is called before the first frame update
    void Start()
    {

        foreach (var position in flatPosition)
        {
            var flatItem = Instantiate(itemPre);

            flatItem.transform.parent = transform;
            flatItem.transform.position = position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
