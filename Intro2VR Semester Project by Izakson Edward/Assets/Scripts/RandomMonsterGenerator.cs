using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMonsterGenerator : MonoBehaviour
{
    public GameObject[] diffMonsters;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Random.Range(10,15); i++)
        {
            MonsterCount();
        }
    }

    void MonsterCount()
    {
        int monsterIndex = Random.Range(0, diffMonsters.Length);
        GameObject rMonster = Instantiate(diffMonsters[monsterIndex]);
        rMonster.transform.parent = transform;
        rMonster.transform.localPosition = new Vector3(Random.Range(-9,9),0,Random.Range(-9,9));
    }
}
