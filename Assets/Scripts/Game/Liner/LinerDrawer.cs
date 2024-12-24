using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LinerDrawer : MonoBehaviour
{
    public float distance;
    [SerializeField] private GameObject solder;
    public UnityEvent<Transform, Transform> StartMoveSolder;

    [SerializeField]private LineRenderer lineRenderer;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer �� ������! ���������, ��� LineRenderer �������� � �������.", gameObject);
        }
    }
    void Start()
    {
        lineRenderer.positionCount = 2;
        // ���������� ������ �����
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;

    }

    public void LinerDraw(Transform startObject, Transform targetObject)
    {
        distance = Vector3.Distance(startObject.position, targetObject.position);
        if (startObject != null && targetObject != null)
        {
            lineRenderer.SetPosition(0, startObject.position);
            lineRenderer.SetPosition(1, targetObject.position);
            Debug.Log(distance);
            // ��������� ���������� �������� ����� �����
            if (lineRenderer.material != null)
            {
                // ��������� ����������� (��������, 1f / ������ ������� � ��������)
                float textureRepeatCount = distance * 2f; // ��� ������ �����������, ��� ������ ���������
                lineRenderer.material.mainTextureScale = new Vector2(textureRepeatCount, 1f);
            }
            Instantiate(solder, startObject.position, Quaternion.identity, transform.transform);
            StartMoveSolder.Invoke(startObject, targetObject);
        }
    }
}
