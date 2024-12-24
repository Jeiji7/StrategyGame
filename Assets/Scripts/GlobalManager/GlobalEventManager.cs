using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent InformationEventActive = new();
    public static UnityEvent InformationEventNotActive = new();

    public static UnityEvent LvlUpButtonActive = new();
    public static UnityEvent LvlUpButtonNotActive = new();

    public static UnityEvent UpDataPeople = new();
    public static UnityEvent UpDataGold = new();
}
