using UnityEngine;

public class PLayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float turnSpeed = 100.0f;
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * vertical);
        transform.root.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontal);

    }
}
