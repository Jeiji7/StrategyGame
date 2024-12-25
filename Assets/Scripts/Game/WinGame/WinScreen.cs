using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public List<GameObject> gameObjectPlayerList = new List<GameObject>();
    public TMP_Text textWinerName;
    public GameObject WinnerScreen;

    private void Update()
    {
        CheckRemainingObject();
    }

    public void CheckRemainingObject()
    {
        // ������� ��� �������� ������� � ������
        List<GameObject> activeObjects = gameObjectPlayerList.FindAll(obj => obj != null && obj.activeInHierarchy);

        // ���� �������� ������ 1 �������� ������
        if (gameObjectPlayerList.Count == 1)
        {
            WinnerScreen.SetActive(true);
            Player player = activeObjects[0].GetComponent<Player>();
            textWinerName.text = $"������� ���������: {player.nameOwner}!!";
        }
    }

    // ������� ��� �������� ������� �� ������
    public void RemoveObjectFromList(GameObject objectToRemove)
    {
        // ���������, ���������� �� ������ � ������ � ������� ���
        if (gameObjectPlayerList.Contains(objectToRemove))
        {
            gameObjectPlayerList.Remove(objectToRemove);
            objectToRemove.SetActive(false);  // ������������ ������, ����� �� ������ �� ���������� � ��������
        }
    }
}

