using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [HideInInspector] public int pairAmount;
    public List<Sprite> spriteList = new List<Sprite>();

    float offSet = 1.2f; // Offset between the cards
    public GameObject cardPrefab;

    public List<GameObject> cardDeck = new List<GameObject>();
    [HideInInspector] public int width;
    [HideInInspector] public int height;

    // Start is called before the first frame update
    void Start()
    {
        GameManager3D.instance.SetPairs(pairAmount);
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
                newCard.GetComponent<Card3D>().SetCard(i, tempSprites[randomSpriteIndex]);
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
        float alignWidthCenter = (offSet * width - offSet) / 2;
        float alignHeightCenter = (offSet * height - offSet) / 2;

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 pos = new Vector3(x * offSet - alignWidthCenter, 0, z * offSet - alignHeightCenter);
                cardDeck[num].transform.position = pos;
                num++;
            }
        }

    }

    void OnDrawGizmos()
    {
        float alignWidthCenter = (offSet * width - offSet) / 2;
        float alignHeightCenter = (offSet * height - offSet) / 2;

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 pos = new Vector3(x * offSet - alignWidthCenter, 0, z * offSet - alignHeightCenter);
                Gizmos.DrawWireCube(pos, new Vector3(1, 0.1f, 1));
            }
        }
    }
}
