using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stage",menuName = "New Stage/Stage")]
public class Stage : ScriptableObject
{
    public int StageNumber;
    public List<Card> Monsters = new List<Card>();
    public Stage nextStage;
}
