using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card3D : MonoBehaviour
{
    protected int cardID;
    public SpriteRenderer cardFront;
    public Animator animator;
    public GameObject FX_Confetti;

    public void SetCard(int id, Sprite sprite)
    {
        cardID = id;
        cardFront.sprite = sprite;
        animator.SetBool("flippedOpen", false);
    }

    public int GetCardID()
    {
        return cardID;
    }

    public void FlipOpen(bool flipped)
    {
        animator.SetBool("flippedOpen", flipped);
    }

    public bool IsFlipped()
    {
        return animator.GetBool("flippedOpen");
    }

    public void ActivateConfetti()
    {
        FX_Confetti.SetActive(true);
    }
}
