using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartidgeBehaviour : MonoBehaviour
{
    public GameObject Cartridge1;
    public GameObject Cartridge2;
    public GameObject Cartridge3;
    // Start is called before the first frame update
    void Start()
    {
        Cartridge1.SetActive(false);
        Cartridge2.SetActive(false);
        Cartridge3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
