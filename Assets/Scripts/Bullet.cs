using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] [Min(0)] private float speed = 20f;

    void FixedUpdate()
    {
        transform.position = transform.position + transform.forward * speed * Time.fixedDeltaTime;
        Destroy(gameObject, 5f);
    }
}
