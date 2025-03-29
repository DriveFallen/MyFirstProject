using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private int ID;
    [Space]
    [Header("аћср 1")]
    [SerializeField] private float Speed1;

    [Space]
    [Header("аћср 2")]
    [SerializeField] private float Speed2;
    [SerializeField] private float Angle;
    [SerializeField] private int Steps;
    private float timeElapsed;
    private Vector3 startPosition2;

    [Space]
    [Header("аћср 3")]
    [SerializeField] private float Speed3;
    [SerializeField] [Range(1,5)] private float Range;
    private Vector3 startPosition3;
    private bool Upper;

    private void Start()
    {
        startPosition2 = transform.position;
        startPosition3 = transform.position;
        timeElapsed = 0;
        Upper = true;

        Debug.Log(startPosition3.y);
        Debug.Log(startPosition3.y + Range);
    }


    private void Update()
    {
        if (ID == 1)
        {
            transform.Rotate(0, Speed1, 0);
        }

        if (ID == 2)
        {
            if (Steps == 0) return;

            timeElapsed += Time.deltaTime;

            float x = startPosition2.x;
            float y = startPosition2.y + (Speed2 * timeElapsed * Mathf.Sin(Angle * Mathf.Deg2Rad) - 0.5f * Physics.gravity.magnitude * timeElapsed * timeElapsed);
            float z = startPosition2.z - Speed2 * timeElapsed * Mathf.Cos(Angle * Mathf.Deg2Rad);

            transform.position = new Vector3(x, y, z);

            if (y < startPosition2.y)
            {
                timeElapsed = 0;
                Steps -= 1;
                startPosition2 = transform.position;
            }
        }

        if (ID == 3)
        {
            if (transform.position.y >= startPosition3.y + Range)
            {
                Upper = false;
            }
            else if (transform.position.y <= startPosition3.y - Range)
            {
                Upper = true;
            }

            if (Upper)
            {
                transform.position += transform.up * Speed3 * Time.fixedDeltaTime;
            }
            else
            {
                transform.position -= transform.up * Speed3 * Time.fixedDeltaTime;
            }
        }
    }
}
