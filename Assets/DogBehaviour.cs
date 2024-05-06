using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviour : MonoBehaviour
{
    public GameObject Dog;
    public float Speed = 10f;
    public Vector3 wantedPositon;
    public Vector3 wantedJumpPosition;

    void Start()
    {
    }

    void Update()
    {

        if ( Dog.transform.position == wantedPositon)
        {
            wantedPositon = wantedJumpPosition;
            Dog.transform.position = Vector3.MoveTowards(transform.position, wantedPositon, (Speed * 2) * Time.deltaTime);
            if (Dog.transform.position == wantedJumpPosition)
            {
                GameAManager.Instance.SpawnDuck(0);
                Destroy(Dog);
            }
        }
        else
        {
            Dog.transform.position = Vector3.MoveTowards(transform.position, wantedPositon, Speed * Time.deltaTime);
        }
    }

}
