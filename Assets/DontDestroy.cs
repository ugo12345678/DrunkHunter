using TMPro;
using UnityEngine;
 
 
public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
