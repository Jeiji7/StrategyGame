using System.Collections.Generic;
using UnityEngine;

public class LandManager : MonoBehaviour
{
    public List<LandWork> landList = new List<LandWork>();
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out LandWork component))
            {
                landList.Add(component);
            }
        }
        foreach(var land in landList)
        {
            SetDefaultValues(land);
        }
    }

    private void SetDefaultValues(LandWork land)
    {
        // land.owner = 0;
        land.people = Random.Range(10,30);
        land.gold = Random.Range(80, 150);
        land.food = land.people * 3;
        land.peopleDayCount = 1;
        land.foodDayCount = 1;
        land.goldDayCount = 1;
    }


}
