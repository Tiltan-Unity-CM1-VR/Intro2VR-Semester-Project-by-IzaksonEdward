using UnityEngine;

public class WalkAndShoot : MonoBehaviour
{
    public GameObject pokeBall;

    public float throwingSpeed = 10f;

    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;

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
