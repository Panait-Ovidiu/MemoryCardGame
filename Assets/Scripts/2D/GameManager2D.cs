using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2D : MonoBehaviour
{
    public static GameManager2D instance;

    bool gameOver;
    bool picked; // Set true if 2 cards are picked
    int pairs;
    int pairCounter;
    public bool hideMatches;
    public int scorePerMatch = 75;

    public GameObject winPanel;
    public GameObject losePanel;

    List<Card2D> pickedCards = new List<Card2D>();

    private void Awake()
    {
        instance = this;
        hideMatches = Menu.isHideMatches();
    }

    private void Start()
    {
        hideMatches = Menu.hideMatches;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void AddCardToPickedList(Card2D card)
    {
        pickedCards.Add(card);
        if (pickedCards.Count == 2)
        {
            picked = true;
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(0.4f);
        if (pickedCards[0].GetCardID() == pickedCards[1].GetCardID())
        {
            // We have a match
            pairCounter++;
            CheckForWin();

            pickedCards[0].ActivateConfetti();
            pickedCards[1].ActivateConfetti();

            ScoreManager2D.instance.AddScore(scorePerMatch);

            yield return new WaitForSeconds(0.4f);

            if (hideMatches)
            {
                pickedCards[0].gameObject.SetActive(false);
                pickedCards[1].gameObject.SetActive(false);
            }
            else
            {
                pickedCards[0].GetComponent<BoxCollider2D>().enabled = false;
                pickedCards[1].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else
        {
            pickedCards[0].FlipOpen(false);
            pickedCards[1].FlipOpen(false);
            yield return new WaitForSeconds(0.4f);
        }

        // Clean up
        picked = false;
        pickedCards.Clear();
        ScoreManager2D.instance.AddTurn();
    }

    void CheckForWin()
    {
        if (pairs == pairCounter)
        {
            // We won
            winPanel.SetActive(true);
            ScoreManager2D.instance.StopTimer();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        losePanel.SetActive(true);
    }

    public bool HasPicked()
    {
        return picked;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void SetPairs(int pairAmout)
    {
        pairs = pairAmout;
    }
}

