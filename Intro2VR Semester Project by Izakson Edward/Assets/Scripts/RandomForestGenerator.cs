using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForestGenerator : MonoBehaviour
{
    public GameObject[] environmentPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Random.Range(750, 800); i++)
        {
            EnvironmentElementsCount();
        }
    }

    void EnvironmentElementsCount()
    {
        int environmentIndex = Random.Range(0, environmentPrefabs.Length);
        GameObject rEnvironment = Instantiate(environmentPrefabs[environmentIndex]);
        rEnvironment.transform.parent = transform;
        rEnvironment.transform.localPosition = new Vector3(Random.Range(-95, 95), 0, Random.Range(-95, 95));
    }
}
