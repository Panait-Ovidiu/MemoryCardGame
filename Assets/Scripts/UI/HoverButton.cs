using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform Button;

    // Start is called before the first frame update
    void Start()
    {
        Button.GetComponent<Animator>().Play("ButtonIdle");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Button.GetComponent<Animator>().Play("ButtonHoverOn");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Button.GetComponent<Animator>().Play("ButtonHoverOff");
    }

}
