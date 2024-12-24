using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // �������� �����������

    [Header("Movement Bounds")]
    public Vector2 minBounds = new Vector2(-8f, -8f); // ����������� ������� (X, Y)
    public Vector2 maxBounds = new Vector2(8f, 8f); // ������������ ������� (X, Y)

    private void Update()
    {
        // ��������� ���� ������������
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // ���������� ������
        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

        // ������������ ��������� �������
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        transform.position = newPosition;
    }
}
