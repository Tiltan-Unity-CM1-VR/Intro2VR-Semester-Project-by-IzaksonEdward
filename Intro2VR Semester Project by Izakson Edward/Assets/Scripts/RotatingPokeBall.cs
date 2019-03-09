using UnityEngine;

public class RotatingPokeBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(300, 300, 300) * Time.deltaTime);
    }
}
