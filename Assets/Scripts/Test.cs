using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        Debug.Log("�����");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("���� �� ���");
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("������ 1");
        }
        
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log("������ 2");
        }
        
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("������ 3");
        }

        //if (Input.GetKey(KeyCode.Alpha1))
        //{
        //    Debug.Log("������ 1");
        //}
        //else if (Input.GetKey(KeyCode.Alpha2))
        //{
        //    Debug.Log("������ 2");
        //} else if (Input.GetKey(KeyCode.Alpha3))
        //{
        //    Debug.Log("������ 3");
        //}
        //else
        //{
        //    Debug.Log("�� ���� ������ �� ������");
        //}
    }
}
