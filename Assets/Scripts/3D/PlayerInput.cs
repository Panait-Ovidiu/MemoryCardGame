using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !GameManager3D.instance.HasPicked() && !GameManager3D.instance.IsGameOver())
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                Card3D currentCard = hit.transform.GetComponent<Card3D>();
                if (currentCard != null)
                {
                    if (!currentCard.IsFlipped())
                    {
                        currentCard.FlipOpen(true);
                        GameManager3D.instance.AddCardToPickedList(currentCard);
                    }
                }
            }
        }
    }
}
