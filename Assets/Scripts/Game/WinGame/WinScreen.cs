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
        // Находим все активные объекты в списке
        List<GameObject> activeObjects = gameObjectPlayerList.FindAll(obj => obj != null && obj.activeInHierarchy);

        // Если осталось только 1 активный объект
        if (gameObjectPlayerList.Count == 1)
        {
            WinnerScreen.SetActive(true);
            Player player = activeObjects[0].GetComponent<Player>();
            textWinerName.text = $"Победил правитель: {player.nameOwner}!!";
        }
    }

    // Функция для удаления объекта из списка
    public void RemoveObjectFromList(GameObject objectToRemove)
    {
        // Проверяем, существует ли объект в списке и удаляем его
        if (gameObjectPlayerList.Contains(objectToRemove))
        {
            gameObjectPlayerList.Remove(objectToRemove);
            objectToRemove.SetActive(false);  // Деактивируем объект, чтобы он больше не участвовал в подсчете
        }
    }
}

