using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectableObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // Для изменения визуального вида объекта
    private Color originalColor; // Исходный цвет
    public Color selectedColor = Color.yellow; // Цвет выделения
    private ObjectSelectionManager selectionManager; // Ссылка на менеджер выделения
    public LandWork landWork;
    private static SelectableObject lastSelectedObject = null;
    public bool isButtonHovered = false;
    private void Start()
    {
        landWork.owner = landWork.PlayerLand.numberOwner;
        if (selectionManager == null)
        {
            selectionManager = FindObjectOfType<ObjectSelectionManager>();
            Debug.LogError("ХММ вот в чём беда");
        }
        SpriteRenderUse();
        Deselect();
    }


    public void SpriteRenderUse()
    {
        landWork.owner = landWork.PlayerLand.numberOwner;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            //originalColor = spriteRenderer.color; // Сохраняем исходный цвет
            originalColor = landWork.PlayerLand.color; // Сохраняем исходный цвет
        }
    }
    private void OnMouseDown()
    {
        if (!isButtonHovered)
        {
            Select();
        }
    }
    public void OnButtonHoverEnter()
    {
        isButtonHovered = true;
    }

    public void OnButtonHoverExit()
    {
        isButtonHovered = false;
    }

    public void IsLandPlayer()
    {
        if (landWork.owner == 1)
        {
            GlobalEventManager.LvlUpButtonActive.Invoke();
        }
        else
        {
            GlobalEventManager.LvlUpButtonNotActive.Invoke();
        }
    }

    private void OnValidate()
    {
        if (selectionManager == null)
        {
            selectionManager = transform.parent.GetComponent<ObjectSelectionManager>();
        }
        if (landWork == null)
        {
            landWork = GetComponent<LandWork>();
        }
    }

    // Метод выделения объекта
    public void Select()
    {
        IsLandPlayer();
        if (landWork.activeUI)
        {
            GlobalEventManager.InformationEventActive.Invoke();
        }
        else
        {
            GlobalEventManager.InformationEventNotActive.Invoke();
        }
        if (lastSelectedObject == this)
        {
            Debug.Log("Данный объект был предыдущим");
            GlobalEventManager.InformationEventNotActive.Invoke();
            selectionManager.Deselect();
            lastSelectedObject = null;
            return;
        }
        else
        {
            selectionManager.Deselect();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = selectedColor;
            }
            selectionManager.SetLandData(landWork);
        }

        lastSelectedObject = this;
    }

    // Метод снятия выделения
    public void Deselect()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }
    }
    public void LvlUpPeople()
    {
        landWork.peopleDayCount += 1;
    }
    public void LvlUpGold()
    {
        landWork.goldDayCount += 1;
    }
}
