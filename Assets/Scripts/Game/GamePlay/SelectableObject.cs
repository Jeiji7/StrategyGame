using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectableObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // ��� ��������� ����������� ���� �������
    private Color originalColor; // �������� ����
    public Color selectedColor = Color.yellow; // ���� ���������
    private ObjectSelectionManager selectionManager; // ������ �� �������� ���������
    public LandWork landWork;
    private static SelectableObject lastSelectedObject = null;
    public bool isButtonHovered = false;
    private void Start()
    {
        landWork.owner = landWork.PlayerLand.numberOwner;
        if (selectionManager == null)
        {
            selectionManager = FindObjectOfType<ObjectSelectionManager>();
            Debug.LogError("��� ��� � ��� ����");
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
            //originalColor = spriteRenderer.color; // ��������� �������� ����
            originalColor = landWork.PlayerLand.color; // ��������� �������� ����
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

    // ����� ��������� �������
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
            Debug.Log("������ ������ ��� ����������");
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

    // ����� ������ ���������
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
