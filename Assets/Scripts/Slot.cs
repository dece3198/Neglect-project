using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public Card card;
    public List<Image> cardImage = new List<Image>();
    [SerializeField] private GameObject cardObj;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI atk;
    [SerializeField] private Outline outline;

    private void SetColor(float _alpha)
    {
        for(int i = 0; i < cardImage.Count; i++)
        {
            Color color = cardImage[i].color;
            color.a = _alpha;
            cardImage[i].color = color;
        }
    }

    public void AddCard(Card _card)
    {
        card = _card;
        for(int i = 0; i < cardImage.Count; i++)
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
        for(int i = 0; i < cardImage.Count; i++)
        {
            cardImage[i].sprite = null;
        }
        SetColor(0);
        cardObj.SetActive(false);
    }

    

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (cardImage[0].sprite != null)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                DragCard.instance.Dragslot = this;
                DragCard.instance.DragSetImage();
                DragCard.instance.transform.position = eventData.position;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (cardImage[0].sprite != null)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                DragCard.instance.transform.position = eventData.position;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragCard.instance.SetColor(0);
        DragCard.instance.Dragslot = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(DragCard.instance.Dragslot != null)
        {
            Change();
        }

    }

    private void Change()
    {
        Card _tempCard = card;
        AddCard(DragCard.instance.Dragslot.card);

        if(_tempCard == DragCard.instance.Dragslot.card)   
        {
            AddCard(_tempCard.nextCard);
            DragCard.instance.Dragslot.ClearSlot();
            return;
        }

        if(_tempCard != null)
        {
            DragCard.instance.Dragslot.AddCard(_tempCard);
        }
        else
        {
            DragCard.instance.Dragslot.ClearSlot();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (cardImage[0].sprite != null)
        outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (cardImage[0].sprite != null)
            outline.enabled = false;
    }

}
