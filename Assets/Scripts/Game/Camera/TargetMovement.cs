using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Скорость перемещения

    [Header("Movement Bounds")]
    public Vector2 minBounds = new Vector2(-8f, -8f); // Минимальные границы (X, Y)
    public Vector2 maxBounds = new Vector2(8f, 8f); // Максимальные границы (X, Y)

    private void Update()
    {
        // Считываем ввод пользователя
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Перемещаем таргет
        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

        // Ограничиваем положение таргета
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        transform.position = newPosition;
    }
}
