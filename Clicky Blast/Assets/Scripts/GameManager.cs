using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float SpanRate = 1.0f;
    public TextMeshProUGUI ScoreBox;
    public TextMeshProUGUI gameovertext;
    public bool IsGameActive;
    private int Score;
    public Button RestartButton;
    public GameObject TitleScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore (int scoreToAdd)
    {
        Score += scoreToAdd;
        ScoreBox.text = "Score" + Score;
    }
    public void Gameover()
    {
        RestartButton.gameObject.SetActive(true);
        gameovertext.gameObject.SetActive(true);
        IsGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        IsGameActive = true;
        Score = 0;
        SpanRate /= difficulty;

        StartCoroutine(SpanTarget());
        UpdateScore(0);
        TitleScreen.gameObject.SetActive(false);
    }

    IEnumerator SpanTarget()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(SpanRate);
            int indux = Random.Range(0, targets.Count);
            Instantiate(targets[indux]);
        }

       

    }
}
