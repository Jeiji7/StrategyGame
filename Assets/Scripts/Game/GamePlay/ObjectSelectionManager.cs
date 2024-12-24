using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ObjectSelectionManager : MonoBehaviour
{
    [SerializeField]private List<SelectableObject> selectableObjects = new List<SelectableObject>(); // ������ ���� ��������
    public DataListLandState dataListLandState;
    private LandWork currentLandWork;

    private void Start()
    {
        //EventTrigger eventTrigger = obj.GetComponent<EventTrigger>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).TryGetComponent(out SelectableObject component))
            {

                selectableObjects.Add(component);
            }
        }
    }
    public void Deselect()
    {
        foreach(SelectableObject component in selectableObjects)
        {
            component.Deselect();
        }
    }
    public void SetLandData(LandWork landWork)
    {
        if (landWork != null)
        {
            currentLandWork = landWork;
            dataListLandState.SetLandData(landWork); // ������� ������ � ���������
        }
    }

    public LandWork GetCurrentLandWork()
    {
        return currentLandWork; // ���������� ������� ������
    }
}
