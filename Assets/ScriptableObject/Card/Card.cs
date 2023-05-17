using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card",menuName = "New Card/Card")]
public class Card : ScriptableObject
{
    public List<Sprite> cardImage = new List<Sprite>();
    public float Hp;
    public float Atk;
    public Card nextCard;
}
