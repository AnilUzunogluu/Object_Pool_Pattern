using UnityEngine;

public class Drive : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    private const float XBoundary = 9f;

    private float _yPosition;
    private float _zPosition;

    private void Start()
    {
        _yPosition = transform.position.y;
        _zPosition = transform.position.z;
    }

    private void Update()
    {
        MovePlayer();
        Shoot();
    }

    private void MovePlayer()
    {
        var translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
        transform.position = ClampXPosition();
    }

    private Vector3 ClampXPosition()
    {
        var clampedXPosition = Mathf.Clamp(transform.position.x, -XBoundary, XBoundary);

        return new Vector3(clampedXPosition, _yPosition, _zPosition);
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Pool.instance.Get("Bullet");
            if (bullet is not null)
            {
                bullet.transform.position = transform.position;
                bullet.SetActive(true);
            }
        }
    }
}