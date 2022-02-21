using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3D : MonoBehaviour
{
    public static GameManager3D instance;

    bool gameOver;
    bool picked; // Set true if 2 cards are picked
    int pairs;
    int pairCounter;
    public bool hideMatches;
    public int scorePerMatch = 75;

    public GameObject winPanel;
    public GameObject winEffect;
    public GameObject losePanel;

    List<Card3D> pickedCards = new List<Card3D>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        hideMatches = Menu.hideMatches;
        winPanel.SetActive(false);
        winEffect.SetActive(false);
        losePanel.SetActive(false);
    }

    public void AddCardToPickedList(Card3D card)
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
        yield return new WaitForSeconds(0.7f);
        if (pickedCards[0].GetCardID() == pickedCards[1].GetCardID())
        {
            // We have a match
            pairCounter++;
            CheckForWin();

            pickedCards[0].ActivateConfetti();
            pickedCards[1].ActivateConfetti();

            ScoreManager.instance.AddScore(scorePerMatch);

            yield return new WaitForSeconds(0.4f);

            if (hideMatches)
            {
                pickedCards[0].gameObject.SetActive(false);
                pickedCards[1].gameObject.SetActive(false);
            }
            else
            {
                pickedCards[0].GetComponent<BoxCollider>().enabled = false;
                pickedCards[1].GetComponent<BoxCollider>().enabled = false;
            }
        }
        else
        {
            pickedCards[0].FlipOpen(false);
            pickedCards[1].FlipOpen(false);
            yield return new WaitForSeconds(0.7f);
        }

        // Clean up
        picked = false;
        pickedCards.Clear();
        ScoreManager.instance.AddTurn();
    }

    void CheckForWin()
    {
        if (pairs == pairCounter)
        {
            // We won
            winPanel.SetActive(true);
            winEffect.SetActive(true);
            ScoreManager.instance.StopTimer();
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
