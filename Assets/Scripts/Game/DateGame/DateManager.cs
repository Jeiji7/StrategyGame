using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

public class DateManager : MonoBehaviour
{
    [Header("ResourceGamePlay")]
    public UnityEvent OnLandWork = new();
    public UnityEvent OnFifhtDayStart = new();
    public UnityEvent OnTenthDayStart = new();

    [Header("UI")]
    [SerializeField] private TMP_Text dateText;
    [SerializeField] private Button _pause;
    [SerializeField] public int _pauseCount = 0;
    [SerializeField] private Button _start;
    [SerializeField] private Button _acceleration;
    [Header("Logical")]
    private DateTime _timeOfPeace = new DateTime(420, 1, 1);
    [SerializeField] public float _oneDayTime = 3f;
    [SerializeField] private float _timer = 0f;

    private int _totalDayCount;
    private void Start()
    {
        DateTextUpdate();
        _start.onClick.AddListener(OnStartClicked);
        _acceleration.onClick.AddListener(OnAccelerationClicked);
        _pause.onClick.AddListener(OnPauseClicked);
    }
    private void Update()
    {
        if (_pauseCount == 0)
            CommonDateSpeed();
        else
            return;
    }

    private void CommonDateSpeed()
    {
        _timer += Time.deltaTime;
        if (_timer >= _oneDayTime)
        {
            _timeOfPeace = _timeOfPeace.AddDays(1);
            _totalDayCount += 1;
            Debug.LogError($"_totalDayCount {_totalDayCount}");
            if (_totalDayCount % 15 == 0)
            {
                //Debug.LogError($"OnFifhtDayStart");
                OnFifhtDayStart.Invoke();
            }
            if (_totalDayCount % 30 == 0)
            {
                //Debug.LogError($"OnTenthDayStart");
                OnTenthDayStart.Invoke();
            }


            OnLandWork.Invoke();
            //������� ���� �����������
            _timer = 0f;
            if (dateText != null)
            {
                DateTextUpdate();
            }
        }
    }
    private void DateTextUpdate()
    {
        dateText.text = _timeOfPeace.ToString($"{_timeOfPeace.Day} MMMM {_timeOfPeace.Year} �.");
    }
    private void OnStartClicked()
    {
        _oneDayTime = 3f;
        _pauseCount = 0;
    }
    private void OnAccelerationClicked()
    {
        _oneDayTime = 1f;
        _pauseCount = 0;
    }
    private void OnPauseClicked()
    {
        _pauseCount = 1;
    }
}
