using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject best;
    public GameObject newBest;
    public GameObject returnButton;
    public GameObject leaderboardButton;
    public GameObject gameOver;
    public GameObject scoreCanvas;
    public GameObject scoreText;

    public Animator animator;
    public Animator overText;
    public Animator leader;
    public Animator returnB;

    void Start()
    {
        returnButton.SetActive(false);
        leaderboardButton.SetActive(false);
        gameOver.SetActive(false);
        scoreCanvas.SetActive(false);
        scoreText.SetActive(true);
    }


    public void OnDeath()
    {
        StartCoroutine(Death());
    }

    public IEnumerator Death()
    {
        Drop.isStarted = true;

        yield return new WaitForSeconds(0.25f);
        Time.timeScale = 0;

        FindObjectOfType<AudioManager>().ButtonPressed("Falling");
        Highscore.SetHighScore();

        yield return new WaitForSecondsRealtime(0.4f);

        if (Highscore.currentHigh < ScoreScript.scoreValue){
            best.SetActive(false);
            newBest.SetActive(true);
        }
        else{
            best.SetActive(true);
            newBest.SetActive(false);
        }

        scoreText.SetActive(false);
        SetScore.Score();

        ButtonsManager.isDead = true;

        returnButton.SetActive(true);
        returnB.SetBool("isOver", true);

        leaderboardButton.SetActive(true);
        leader.SetBool("isOver", true);

        gameOver.SetActive(true);
        overText.SetBool("isOver", true);

        scoreCanvas.SetActive(true);
        animator.SetBool("isGameOver", true);

    }
}
