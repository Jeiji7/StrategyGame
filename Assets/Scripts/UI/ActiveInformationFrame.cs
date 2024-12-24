using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActiveInformationFrame : MonoBehaviour
{
    public GameObject information;
    
    private void Awake()
    {
        GlobalEventManager.InformationEventActive.AddListener(ActiveInformation);
        GlobalEventManager.InformationEventNotActive.AddListener(NotActiveInformation);

    }

    public void ActiveInformation()
    {
        information.SetActive(true);
    }
    public void NotActiveInformation()
    {
        information.SetActive(false);
    }
}
