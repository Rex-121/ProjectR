using UnityEngine;

public class LockFPS : MonoBehaviour
{

    [SerializeField]
    int frame = 60;

    // Start is called before the first frame update
    void Start()
    {
        
        Application.targetFrameRate = frame;
    }

}
