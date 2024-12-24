using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // Объект, за которым будет следовать камера
    public Vector3 offset = new Vector3(0, 0, -10); // Смещение камеры относительно цели

    [Header("Smoothness Settings")]
    public float smoothSpeed = 0.125f; // Скорость плавности (чем меньше, тем плавнее)

    private void FixedUpdate()
    {
        if (target != null)
        {
            // Следуем за целью без ограничений
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;
        }
    }
}
