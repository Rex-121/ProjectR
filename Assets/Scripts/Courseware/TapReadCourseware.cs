using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapReadCourseware : MonoBehaviour
{

    [SerializeField]
    private Transform board;

    public GameObject itemPre;

    void Start()
    {
        var item = new TapReadItem.Usage("https://roobo-test.oss-cn-beijing.aliyuncs.com/appcourse/manager/2021-09-22/c55gk2et0gb0jnjrog3g.wav", "https://roobo-test.oss-cn-beijing.aliyuncs.com/appcourse/manager/2021-07-16/c3on1jln4qt6t4tcobrg.png");

        TapReadItem pre = Instantiate(itemPre).GetComponent<TapReadItem>();
        print("1");
        pre.SetItem(item);
        print("2");
        pre.transform.parent = board;
        print("3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
