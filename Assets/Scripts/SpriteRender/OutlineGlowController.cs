using UnityEngine;

public class OutlineGlowController : MonoBehaviour
{
    public Color outlineColor = Color.yellow;
    public float outlineSize = 0.05f;

    private Material outlineMaterial;

    void Start()
    {
        // �������� �������� �������
        outlineMaterial = GetComponent<SpriteRenderer>().material;

        // ������������� ��������� �������� ��� ����� � ������� �������
        outlineMaterial.SetColor("_OutlineColor", outlineColor);
        outlineMaterial.SetFloat("_OutlineSize", outlineSize);
    }

    void Update()
    {
        // ��������, �� ������ ����������� �������� ���������
        outlineMaterial.SetColor("_OutlineColor", outlineColor);
        outlineMaterial.SetFloat("_OutlineSize", outlineSize);
    }
}
