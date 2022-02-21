using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManger2D : MonoBehaviour
{
    [HideInInspector] public int pairAmount;
    [HideInInspector] public int width;
    [HideInInspector] public int height;
    public List<Sprite> spriteList = new List<Sprite>();

    float cardWidth = 2.68f;
    float cardHeight = 3.88f;
    float offset = 0.5f; // Offset between the cards
    public GameObject cardPrefab;

    public List<GameObject> cardDeck = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameManager2D.instance.SetPairs(pairAmount);
        CreatePlayField();
    }

    void CreatePlayField()
    {
        List<Sprite> tempSprites = new List<Sprite>();
        tempSprites.AddRange(spriteList);

        for (int i = 0; i < pairAmount; i++)
        {
            int randomSpriteIndex = Random.Range(0, tempSprites.Count);
            for (int j = 0; j < 2; j++)
            {
                Vector3 pos = Vector3.zero;
                GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
                newCard.GetComponent<Card2D>().SetCard(i, tempSprites[randomSpriteIndex]);
                cardDeck.Add(newCard);
            }
            tempSprites.RemoveAt(randomSpriteIndex);
        }
        
        // Shuffle Cards
        for (int i = 0; i < cardDeck.Count; i++)
        {
            int index = Random.Range(0, cardDeck.Count);
            var temp = cardDeck[i];
            cardDeck[i] = cardDeck[index];
            cardDeck[index] = temp;
        }

        int num = 0;
        // Position Cards
        float alignWidthCenter = (cardWidth * width - cardWidth) / 2 + offset;
        float alignHeightCenter = (cardHeight * height - cardHeight) / 2 + offset;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(x * (cardWidth + offset) - alignWidthCenter, y * (cardHeight + offset) - alignHeightCenter, 0);
                cardDeck[num].transform.position = pos;
                num++;
            }
        }
    }
}
