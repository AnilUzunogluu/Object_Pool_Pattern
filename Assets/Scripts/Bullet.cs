using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;

    // Update is called once per frame
    private void Update()
    {
        var speed = velocity * Time.deltaTime;
        transform.Translate(speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Asteroid"))
        {
            col.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
