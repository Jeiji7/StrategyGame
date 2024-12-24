using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // ������, �� ������� ����� ��������� ������
    public Vector3 offset = new Vector3(0, 0, -10); // �������� ������ ������������ ����

    [Header("Smoothness Settings")]
    public float smoothSpeed = 0.125f; // �������� ��������� (��� ������, ��� �������)

    private void FixedUpdate()
    {
        if (target != null)
        {
            // ������� �� ����� ��� �����������
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;
        }
    }
}
