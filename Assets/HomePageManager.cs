using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMP_Text BestScoreTxt;
    private bool InGame = false;
    private int BestScore = 0;

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
    }

    // Update is called once per frame
    void Update()
    {
        BestScoreTxt.SetText(BestScore.ToString());
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InGame = true;
            SceneManager.LoadScene("Game A");
        }
        if ( InGame )
        {
            BestScoreTxt.SetText("");
        }

    }

    public void NewBestScore( int  Score )
    {
        InGame = false;
        Debug.Log("new best");
        Debug.Log(Score);
        Debug.Log(Score > BestScore);
        if( Score > BestScore )
        {
            BestScore = Score;
            Debug.Log(BestScoreTxt);
        }
    }
}
