using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    MonsterCalculator mCalculator;
    int monsterCount = 0;
    public Text monsterCountText;

    // Start is called before the first frame update
    void Start()
    {
        mCalculator = FindObjectOfType<MonsterCalculator>();
        monsterCount = mCalculator.counter;
        monsterCountText.text = monsterCount.ToString();
        Destroy(mCalculator.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
