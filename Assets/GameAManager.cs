using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAManager : MonoBehaviour
{
    public GameObject[] Ducks;
    public static GameAManager Instance;
    public Texture2D cursorTexture;
    public GameObject[] CartidgesMasque;
    public GameObject[] DucksHit;
    public GameObject DogShow;
    public TextMeshPro ScoreTxt;
    private int NbShots = 2;
    private int NbHits = 0;
    private int Score = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var DuckHit in DucksHit) 
        { 
            DuckHit.gameObject.SetActive(false);
        }
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        ScoreTxt.SetText(Score.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if ( NbHits == 10 )
        {
            GameManager.Instance.NewBestScore(Score);
            SceneManager.LoadScene("Homepage");
        }
    }

    public void DuckHit()
    {
        if (NbHits < 10)
        {
            CartidgesMasque[0].gameObject.SetActive(false);
            CartidgesMasque[1].gameObject.SetActive(false);
            CartidgesMasque[2].gameObject.SetActive(false);
            NbShots = 2;
            DucksHit[NbHits].gameObject.SetActive(true);
            NbHits++;
            Score = Score + 500;
            ScoreTxt.SetText(Score.ToString());
        }
    }

    public void FailShot()
    {
        if ( NbShots > 0 ) {
            CartidgesMasque[NbShots].gameObject.SetActive(true);
            NbShots --;
        }
        else
        {
            GameManager.Instance.NewBestScore(Score);
            SceneManager.LoadScene("Homepage");
        }
    }

    public void ShowDuck(float x)
    {
        DogShow.SetActive(true);
        DogShow.transform.position = new Vector3(x, -0.8f, 3);
        StartCoroutine(WaitForDesactive(DogShow));
    }

    public void SpawnDuck(int number)
    {
        StartCoroutine(WaitForDuck(number));
    }

    IEnumerator WaitForDuck(int number)
    {
        yield return new WaitForSeconds(1f);
        Ducks[number].gameObject.SetActive(true);
    }

    IEnumerator WaitForDesactive(GameObject go)
    {
        yield return new WaitForSeconds(1f);
        go.SetActive(false);
        if ( NbHits < 10)
        {
            SpawnDuck(NbHits);
        }
    }
}
