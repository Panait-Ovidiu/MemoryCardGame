using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card2D : MonoBehaviour
{
    protected int cardID;
    private bool isFlipped;
    public SpriteRenderer cardFront;
    public GameObject FX_Confetti;

    public void SetCard(int id, Sprite sprite)
    {
        cardID = id;
        cardFront.sprite = sprite;
        isFlipped = false;
    }

    public int GetCardID()
    {
        return cardID;
    }

    public void FlipOpen(bool flipped)
    {
        isFlipped = flipped;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(flipped);
    }

    public bool IsFlipped()
    {
        return isFlipped;
    }

    public void ActivateConfetti()
    {
        FX_Confetti.SetActive(true);
    }
}
