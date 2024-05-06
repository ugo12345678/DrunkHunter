using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DuckBehaviour : MonoBehaviour
{
    public GameObject Duck;
    public float Speed = 10f;
    public Vector3 Center;
    public float MinDistance;
    public Vector3 CoinBasGauche;
    public Vector3 CoinBasDroit;
    public Vector3 CoinHautGauche;
    public Vector3 CoinHautDroit;
    public Animator Animator;
    public SpriteRenderer SpriteRenderer;
    public TextMeshPro HitPoint;
    private Vector3[] SquarePoints = new Vector3[4];
    private Vector3 wantedPositon;
    private bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        Duck.SetActive(false);
        SquarePoints[0] = CoinHautGauche;
        SquarePoints[1] = CoinBasGauche;
        SquarePoints[2] = CoinBasDroit;
        SquarePoints[3] = CoinHautDroit;
        wantedPositon = GenerateRandomVector(Center, MinDistance, SquarePoints);
        HitPoint.SetText("");
    }

    private void OnMouseDown()
    {
        hit = true;
        GameAManager.Instance.DuckHit();
        Animator.SetBool("Hit", true);
        HitPoint.SetText("500");
        HitPoint.transform.position = Duck.transform.position;
        StartCoroutine(WaitSetNull(HitPoint));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( hit == false )
        {
            Vector3 direction = wantedPositon - transform.position;

            if (direction.x > 0)
            {
                SpriteRenderer.flipX = false;
            }
            else if (direction.x < 0)
            {
                SpriteRenderer.flipX = true;
            }

            if (Duck.transform.position == wantedPositon)
            {
                wantedPositon = GenerateRandomVector(Center, MinDistance, SquarePoints);
                Duck.transform.position = Vector3.MoveTowards(transform.position, wantedPositon, (Speed * 2) * Time.deltaTime);
            }
            else
            {
                Duck.transform.position = Vector3.MoveTowards(transform.position, wantedPositon, Speed * Time.deltaTime);
            }
        }
        else
        {
            
            wantedPositon = new Vector3(transform.position.x,-2f,3);
            Duck.transform.position = Vector3.MoveTowards(transform.position, wantedPositon, (Speed * 2) * Time.deltaTime);

            if (Duck.transform.position == wantedPositon)
            {
                GameAManager.Instance.ShowDuck(transform.position.x);
                Destroy(Duck);
            }
        }

    }

    public Vector3 GenerateRandomVector(Vector3 center, float minDistance, Vector3[] squarePoints)
    {
        Vector3 randomVector;
        do
        {
            float x = Random.Range(Mathf.Min(squarePoints[0].x, squarePoints[1].x), Mathf.Max(squarePoints[2].x, squarePoints[3].x));
            float y = Random.Range(Mathf.Min(squarePoints[0].y, squarePoints[2].y), Mathf.Max(squarePoints[1].y, squarePoints[3].y));
            float z = Random.Range(Mathf.Min(squarePoints[0].z, squarePoints[2].z), Mathf.Max(squarePoints[1].z, squarePoints[3].z));

            randomVector = new Vector3(x, y, z);
        }
        while (Vector3.Distance(randomVector, center) < minDistance);

        return randomVector;
    }

    IEnumerator WaitSetNull(TextMeshPro txt)
    {
        yield return new WaitForSeconds(2f);
        txt.SetText("aaa");
    }
}

