using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;
using UnityEngine.UI;

public class MonsterGenerator : MonoBehaviour
{
    [SerializeField] private Stage stage;
    [SerializeField] private Slider slider;
    [SerializeField] private Battle battle;
    private float maxTime;
    private float curTime;

    private void Awake()
    {
        maxTime = 60;
        curTime = 60;
    }

    private void Update()
    {
        if(curTime > 0)
        {
            curTime -= Time.deltaTime * 10;
            slider.value = curTime / maxTime;
        }
        else
        {
            slider.gameObject.SetActive(false);
            StageStart(stage.nextStage);
        }
    }

    private void StageStart(Stage stage)
    {
        for(int i = 0; i < stage.Monsters.Count; i++)
        {
            transform.GetChild(i).GetComponent<MonsterCard>().AddCard(stage.Monsters[i]);
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
