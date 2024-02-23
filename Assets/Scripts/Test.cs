using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Старт");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Клик по ЛКМ");
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("Кнопка 1");
        }
        
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log("Кнопка 2");
        }
        
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("Кнопка 3");
        }

        //if (Input.GetKey(KeyCode.Alpha1))
        //{
        //    Debug.Log("Кнопка 1");
        //}
        //else if (Input.GetKey(KeyCode.Alpha2))
        //{
        //    Debug.Log("Кнопка 2");
        //} else if (Input.GetKey(KeyCode.Alpha3))
        //{
        //    Debug.Log("Кнопка 3");
        //}
        //else
        //{
        //    Debug.Log("Ни одна кнопка не зажата");
        //}
    }
}
