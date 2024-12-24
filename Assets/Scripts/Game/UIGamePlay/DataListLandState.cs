using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class DataListLandState : MonoBehaviour
{
   
    public  GameObject LvlUpPeople;
    public  GameObject LvlUpGold;
    [SerializeField] private TMP_Text _nameLand;
    [SerializeField] private TMP_Text _countPeople;
    [SerializeField] private TMP_Text _countFood;
    [SerializeField] private TMP_Text _countGold;
    [SerializeField] private TMP_Text _peopleDayCount;
    [SerializeField] private TMP_Text _foodDayCount;
    [SerializeField] private TMP_Text _goldDayCount;

    public ObjectSelectionManager objectSelectionManager;
    private void Awake()
    {
        GlobalEventManager.LvlUpButtonActive.AddListener(ActiveLvlUp);
        GlobalEventManager.LvlUpButtonNotActive.AddListener(NotActiveLvlUp);
    }
   
    public void LvlUpPeopleButton()
    {
        GlobalEventManager.UpDataPeople.Invoke();
    }
    public void LvlUpGoldButton()
    {
        GlobalEventManager.UpDataGold.Invoke();
    }
    private void ActiveLvlUp()
    {
        LvlUpPeople.SetActive(true);
        LvlUpGold.SetActive(true);
    }
    private void NotActiveLvlUp()
    {
        LvlUpPeople.SetActive(false);
        LvlUpGold.SetActive(false);
    }
    private void Update()
    {
        SetLandData(objectSelectionManager.GetCurrentLandWork());

    }
    public void SetLandData(LandWork landWork)
    {
        if (landWork != null)
        {
            UpdateData(
                landWork.nameUnit,
                landWork.people,
                landWork.food,
                landWork.gold,
                landWork.peopleDayCount,
                landWork.foodDayCount,
                landWork.goldDayCount
            );
        }
    }
    private void UpdateData(string name, int countPeople, int countFood, int countGold, int peopleDayCount, int foodDayCount, int goldDayCount)
    {
        _nameLand.text = name;
        _countPeople.text = countPeople.ToString();
        _countFood.text = countFood.ToString();
        _countGold.text = countGold.ToString();
        _peopleDayCount.text = ($"зол/в день {peopleDayCount}").ToString();
        _foodDayCount.text = foodDayCount.ToString();
        _goldDayCount.text = ($"зол/в день {goldDayCount}").ToString();
    }
}
