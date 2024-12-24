using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string nameUnit; // имя области
    private int _people; // число людей на области
    private int _food;
    private int _gold;
    private int _peopleDayCount;
    private int _foodDayCount;
    private int _goldDayCount;
    public int owner;
    public bool activeUI = true;
   
    public int peopleDayCount
    {
        get { return _peopleDayCount; }
        set
        {
            if (value >= 4)
                Debug.LogError("максимальный уровенень");
            else
                _peopleDayCount = value;
        }
    }// прибавление людей на область
    public int foodDayCount
    {
        get { return _foodDayCount; }
        set
        {
            if (value < 0 || value >= 4)
                Debug.LogError("максимальный уровенень");
            else
                _foodDayCount = value;
        }
    }
    public int goldDayCount
    {
        get { return _goldDayCount; }
        set
        {
            if (value < 0 || value >= 4)
                Debug.LogError($"максимальный уровенень {_goldDayCount}");
            else
                _goldDayCount = value;
        }
    }
    
    public int people
    {
        get { return _people; }
        set
        {
            if (value <= 0 || value >= 10001)
            {
                Debug.Log($"Ошибка в количестве людей {value}");
                return;
            }
            else
            {
                _people = value;
            }
        }
    }
    public int food
    {
        get { return _food; }
        set
        {
            if (value <= 0 || value >= 30001)
            {
                Debug.Log($"Ошибка в количестве еды {value}");
                return;
            }
            else
            {
                _food = value;
            }
        }
    }
    public int gold
    {
        get { return _gold; }
        set
        {
            if (value <= 0 || value >= 5001)
            {
                Debug.Log($"золота макс или иная ошибка {value}");
                return;
            }
            else
            {
                _gold = value;
            }
        }
    }
}
