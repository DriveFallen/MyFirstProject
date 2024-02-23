using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    [Header("Пропеллер")]
    [SerializeField] private GameObject rotator_object;
    [Space]
    [Space]
    [Header("Самолёт")]
    [SerializeField] private string airplaneName = "UA-265";
    [SerializeField] [Range(0, 100)] private float speed = 1;
    [SerializeField] [Range(0, 100)] private float rotationSpeed = 5f;
    [SerializeField] [Min(0)] private int ammunitionCount = 30;
    [Space]
    [Space]
    [Header("Точки для спавна префабов")]
    [SerializeField] private Transform rightFirePoint;
    [SerializeField] private Transform leftFirePoint;
    [SerializeField] private Transform smokeSpawnPoint;
    [Header("Префабы")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject smokePrefab;
    [Space]
    [Space]
    [SerializeField] [Range(0, 5)] private float fireRate = 0.1f;
    private float timeToFire = 0f;
    [SerializeField] [Range(0, 1)] private float smokeRate = 0.1f;
    private float timeToSmoke = 0f;

    private float currentSpeed;
    private Vector3 direction;
    private Vector3 targetDirection;

    void Start()
    {
        gameObject.name = airplaneName;
        currentSpeed = speed;
    }

    void Update()
    {
        DirectionalInput();

        if (Input.GetKey(KeyCode.Mouse0) && timeToFire < Time.time)
        {
            Shot();
            timeToFire = Time.time + fireRate;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2;
        }

        //последнее ДЗ по этому проекту
        if (timeToSmoke < Time.time)
        {
            GameObject newSmoke = Instantiate(smokePrefab);
            newSmoke.transform.position = smokeSpawnPoint.position;
            newSmoke.transform.rotation = smokeSpawnPoint.rotation;
            Destroy(newSmoke, 1.2f);
            timeToSmoke = Time.time + smokeRate / speed; // убрать деление на speed, если нужно создавать реже при быстрой скорости
        }

        //Debug.Log("Скорость: " + speed);
    }

    private void FixedUpdate()
    {
        Movement();

        rotator_object.transform.Rotate(new Vector3(0, 0, 30f));
    }

    private void Movement()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, speed, Time.fixedDeltaTime);

        transform.position += transform.forward * currentSpeed * Time.fixedDeltaTime;

        transform.Rotate(direction);
    }

    private void DirectionalInput()
    {
        float horizontal;
        float vertical;

        if (Input.GetKey(KeyCode.W))
        {
            vertical = -1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vertical = 1;
        }
        else
        {
            vertical = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontal = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = -1;
        }
        else
        {
            horizontal = 0;
        }

        targetDirection.Set(vertical, 0, horizontal * rotationSpeed);
        direction = Vector3.Lerp(direction, targetDirection, Time.fixedDeltaTime);
    }

    private void Shot()
    {
        if (ammunitionCount > 0)
        {
            ammunitionCount -= 1;

            GameObject BulletLeft = Instantiate(bulletPrefab);
            BulletLeft.transform.position = leftFirePoint.position;
            BulletLeft.transform.rotation = leftFirePoint.rotation;

            GameObject BulletRight = Instantiate(bulletPrefab);
            BulletRight.transform.position = rightFirePoint.position;
            BulletRight.transform.rotation = rightFirePoint.rotation;

            Debug.Log(airplaneName + " выстрелил");
            Debug.Log("Боеприпасов осталось: " + ammunitionCount);
        }
        else
        {
            Debug.Log("Боеприпасы кончились");
        }
    }
}
