using UnityEngine;

public class MonstersCollected : MonoBehaviour
{
    MonsterCalculator mCalculator;

    void Start()
    {
        mCalculator = FindObjectOfType<MonsterCalculator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedMonster"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            mCalculator.TotalCount();
        }
        if (other.CompareTag("VioletMonster"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            mCalculator.TotalCount();
        }
        if (other.CompareTag("YellowMonster"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            mCalculator.TotalCount();
        }
        if (other.CompareTag("BlueMonster"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            mCalculator.TotalCount();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
