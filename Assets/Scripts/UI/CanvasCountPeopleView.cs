using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class CanvasCountPeopleView : MonoBehaviour
{
    [SerializeField] private LandWork landWork;
    [SerializeField]private TMP_Text countPeople;
    public UnityEvent OnUpdatePeopleUI;
    private DateManager dateManager;

    private void Awake()
    {

        dateManager = FindFirstObjectByType<DateManager>();
        dateManager.OnLandWork.AddListener(UpdatePeopleText);
    }
    void Start()
    {
        landWork = transform.parent.GetComponent<LandWork>();
        countPeople = transform.Find("CountText").GetComponent<TMP_Text>();
        UpdatePeopleText();
    }
    private void UpdatePeopleText()
    {
        countPeople.text = landWork.people.ToString();
        OnUpdatePeopleUI.Invoke();
    }
    
}
