using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCard : MonoBehaviour
{
    public Card card;
    public List<Image> cardImage = new List<Image>();
    [SerializeField] private GameObject cardObj;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI atk;

    private void Update()
    {
        
    }

    private void SetColor(float _alpha)
    {
        for (int i = 0; i < cardImage.Count; i++)
        {
            Color color = cardImage[i].color;
            color.a = _alpha;
            cardImage[i].color = color;
        }
    }

    public void AddCard(Card _card)
    {
        card = _card;
        for (int i = 0; i < cardImage.Count; i++)
        {
            cardImage[i].sprite = card.cardImage[i];
        }
        hp.text = card.Hp.ToString();
        atk.text = card.Atk.ToString();
        cardObj.SetActive(true);
        SetColor(1);
    }

    private void ClearSlot()
    {
        card = null;
        for (int i = 0; i < cardImage.Count; i++)
        {
            cardImage[i].sprite = null;
        }
        SetColor(0);
        cardObj.SetActive(false);
    }
}
