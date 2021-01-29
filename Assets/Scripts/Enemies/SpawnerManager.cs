using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class SpawnerContent
{
    public GameObject[] content;
}

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private float delay;
    public SpawnerContent[] spawnercontent;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnercontent == null || spawnercontent.Length == 0)
        {
            GameplayManager.Instance.pause = true;
            GameplayManager.Instance.uiPanels[0].SetActive(true);
            GameplayManager.Instance.uiPanels[3].SetActive(true);
        }
    }

    IEnumerator Spawn()
    {

        for (int i = 1; i < spawnercontent[0].content.Length; i++)
        {
            for (int j = 0; j < spawnercontent.Length; j++)
            {
                if (spawnercontent[j].content[i] != null)
                {
                    Instantiate(spawnercontent[j].content[i], spawnercontent[j].content[0].transform.position, Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(delay);
        }


    }
}



