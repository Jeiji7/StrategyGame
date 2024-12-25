using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionUI : MonoBehaviour
{
    public GameObject instruction;
    public GameObject[] gameObjects; // ��������� ������ ������� ��������
    private int currentIndex = 0;

    public void EnterInstruction()
    {
        instruction.SetActive(true);
    }
    public void ExitInstruction()
    {
        instruction.SetActive(false);
    }

    public void ToggleNextObject()
    {
        if (currentIndex >= 0)
        {
            gameObjects[currentIndex].SetActive(false);
        }

        currentIndex = (currentIndex + 1) % gameObjects.Length;
        gameObjects[currentIndex].SetActive(true);
    }

    public void TogglePreviousObject()
    {
        if (currentIndex >= 0)
        {
            gameObjects[currentIndex].SetActive(false);
        }

        currentIndex = (currentIndex - 1 + gameObjects.Length) % gameObjects.Length;
        gameObjects[currentIndex].SetActive(true);
    }
}
