using UnityEngine;

public class WalkAndShoot : MonoBehaviour
{
    public GameObject pokeBall;

    public float throwingSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject pokeBallObj = Instantiate(pokeBall);
            pokeBallObj.transform.position = transform.position;
            Rigidbody rb = pokeBallObj.GetComponent<Rigidbody>();
            Camera camera = GetComponentInChildren<Camera>();
            rb.velocity = camera.transform.rotation * Vector3.forward * throwingSpeed;
        }
    }
}
