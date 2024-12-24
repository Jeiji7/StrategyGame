using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LandWork : Unit
{
    public DateManager dateManager;
    public Player PlayerLand;
  
    private void Awake()
    {
        peopleDayCount = 1;
        foodDayCount = 1;
        goldDayCount = 1;
        dateManager.OnLandWork.AddListener(CreatePeople);
        dateManager.OnLandWork.AddListener(CreateFood);
        dateManager.OnLandWork.AddListener(CreateGold);
    }
    public void CreateFood()
    {
        food += foodDayCount;
    }
    
    public void CreatePeople()
    {
        people += peopleDayCount;
    }
    public void CreateGold()
    {
        gold += goldDayCount;
    }
    

}
