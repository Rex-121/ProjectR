using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
public class Sorting : CoursewareMono
{
    [Header("FLAT")]
    [SerializeField]
    Transform flat;
    [SerializeField]
    GameObject flatPrefab;
    [SerializeField]
    Vector2[] flatPosition;

    [Header("SORT")]
    [SerializeField]
    Transform sortItems;
    [SerializeField]
    GameObject sortPrefab;
    [SerializeField]
    Vector2[] sortPosition;



    void Start()
    {

        var a = new List<string>();
        a.Add("3");
        a.Add("2");
        a.Add("4");
        a.Add("1");
        

        foreach (var position in flatPosition)
        {
            var flatItem = Instantiate(flatPrefab);

            flatItem.name = flatItem.name + "_" + a[0];

            Variables flow = flatItem.GetComponent<Variables>();

            flow.declarations.Set("answer", a[0]);

            a.RemoveAt(0);

            flatItem.transform.parent = flat;
            flatItem.transform.position = position;
        }


        var ab = new List<string>();
        ab.Add("4");
        ab.Add("1");
        ab.Add("3");
        ab.Add("2");


        foreach (var position in sortPosition)
        {
            var sortItem = Instantiate(sortPrefab);

            sortItem.name = sortItem.name + "_" + ab[0];

            var sprite = Resources.Load<Sprite>("Images/Courseware/Sorting/Sort-" + ab[0]);

            sortItem.GetComponent<SpriteRenderer>().sprite = sprite;

            ab.RemoveAt(0);

            sortItem.transform.parent = sortItems;
            sortItem.transform.position = position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
