using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput2D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager2D.instance.HasPicked() && !GameManager2D.instance.IsGameOver())
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            
            if (hit.collider != null)
            {
                Card2D currentCard = hit.transform.GetComponent<Card2D>();
                if(currentCard != null)
                {
                    if(!currentCard.IsFlipped())
                    {
                        currentCard.FlipOpen(true);
                        GameManager2D.instance.AddCardToPickedList(currentCard);
                    }
                }
            }
        }
    }
}
