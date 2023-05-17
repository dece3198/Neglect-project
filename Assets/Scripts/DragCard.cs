using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragCard : MonoBehaviour
{
    static public DragCard instance;

    public Slot Dragslot;
    [SerializeField] private Image cardImage;
    public Image charImage;

    private void Start()
    {
        instance = this;
    }

    public void DragSetImage()
    {
        cardImage.sprite = Dragslot.cardImage[0].sprite;
        charImage.sprite = Dragslot.cardImage[1].sprite;
        SetColor(1);

    }
    public void SetColor(float _alpha)
    {
        Color color = cardImage.color;
        Color color1 = charImage.color;
        color.a = _alpha;
        color1.a = _alpha;
        cardImage.color = color;
        charImage.color = color1;
    }
}
