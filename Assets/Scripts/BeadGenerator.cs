using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Bead = new List<GameObject>();
    [SerializeField]
    private List<GameObject> BeadList = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < Bead.Count; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                GameObject gameObject = Instantiate(Bead[i]);
                BeadList.Add(gameObject);
                gameObject.transform.position = transform.position;
                gameObject.SetActive(false);
                gameObject.transform.parent = transform;
            }
        }

        StartCoroutine(BeadGeneratorCO());
    }


    private IEnumerator BeadGeneratorCO()
    {
        for(int i = 0; i < 9; i++)
        {
            int rand = Random.Range(0, BeadList.Count);
            GameObject gameObject = BeadList[rand];
            gameObject.SetActive(true);
            BeadList.RemoveAt(rand);
            yield return new WaitForSeconds(0.5f);
        }

    }
}
