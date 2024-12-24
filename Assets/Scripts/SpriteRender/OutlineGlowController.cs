using UnityEngine;

public class OutlineGlowController : MonoBehaviour
{
    public Color outlineColor = Color.yellow;
    public float outlineSize = 0.05f;

    private Material outlineMaterial;

    void Start()
    {
        // Получаем материал спрайта
        outlineMaterial = GetComponent<SpriteRenderer>().material;

        // Устанавливаем начальные значения для цвета и размера контура
        outlineMaterial.SetColor("_OutlineColor", outlineColor);
        outlineMaterial.SetFloat("_OutlineSize", outlineSize);
    }

    void Update()
    {
        // Например, вы можете динамически изменять параметры
        outlineMaterial.SetColor("_OutlineColor", outlineColor);
        outlineMaterial.SetFloat("_OutlineSize", outlineSize);
    }
}
