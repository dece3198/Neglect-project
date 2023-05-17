using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Card> cards = new List<Card>();
    [SerializeField]
    private GameObject SlotParent;

    private Slot[] slots;

    private void Start()
    {
        slots = SlotParent.GetComponentsInChildren<Slot>();
    }

    public void AcquireCard(Card card)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].card == null)
            {
                slots[i].AddCard(card);
                return;
            }
        }
    }

    public void Click()
    {
        int rand = Random.Range(0, cards.Count);
        AcquireCard(cards[rand]);
    }

}
