using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{

    private void OnMouseDown()
    {
        GameAManager.Instance.FailShot();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
