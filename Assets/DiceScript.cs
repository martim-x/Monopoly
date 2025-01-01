using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    public float checkThreshold = 0.1f; // Порог остановки движения кубика
    public bool wasStoped = false; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Если кубик остановился, проверяем, какая грань сверху
        if (IsStopped() && !wasStoped)
        {
            int result = GetTopFace();
            if (result != -1)
            {
                Debug.Log("Выпавшая грань: " + result);
            }
            wasStoped = true;
        }
    }

    bool IsStopped()
    {
        // Проверяем, что кубик практически остановился
        return rb.velocity.magnitude < checkThreshold && rb.angularVelocity.magnitude < checkThreshold;
    }

    int GetTopFace()
    {
        // Определяем, какая грань смотрит вверх
        Vector3 upDirection = Vector3.up; // Глобальная ось вверх

        // Проверяем локальные оси кубика относительно глобальной оси вверх
        if (Vector3.Dot(transform.right, upDirection) > 0.9f)
        {
            return 1; // Ось X положительная (грань "1")
        }
        else if (Vector3.Dot(-transform.right, upDirection) > 0.9f)
        {
            return 6; // Ось X отрицательная (грань "6")
        }
        else if (Vector3.Dot(transform.up, upDirection) > 0.9f)
        {
            return 5; // Ось Y положительная (грань "5")
        }
        else if (Vector3.Dot(-transform.up, upDirection) > 0.9f)
        {
            return 2; // Ось Y отрицательная (грань "2")
        }
        else if (Vector3.Dot(transform.forward, upDirection) > 0.9f)
        {
            return 4; // Ось Z положительная (грань "4")
        }
        else if (Vector3.Dot(-transform.forward, upDirection) > 0.9f)
        {
            return 3; // Ось Z отрицательная (грань "3")
        }

        return -1; // Ничего не определено
    }
}
