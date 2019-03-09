using UnityEngine;

public class MonsterCalculator : MonoBehaviour
{
    public int counter;
    public TextMesh totalTextMesh;
    void Start()
    {
        counter = 0;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }

    public void TotalCount()
    {
        counter = counter + 1;
        totalTextMesh.text = counter.ToString();
    }
}
