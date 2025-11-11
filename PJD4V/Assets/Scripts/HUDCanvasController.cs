using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDCanvasController : MonoBehaviour
{
    public static HUDCanvasController Instance;

    public GameObject livesObject;
    public GameObject energyBarObject;
    public GameObject coinsObject;
    public GameObject timerObject;
    
    private void OnEnable()
    {
        HUDObserverManager.ONActivateHUD += OnActivateHUD;
    }

    private void OnDisable()
    {
        HUDObserverManager.ONActivateHUD -= OnActivateHUD;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void OnActivateHUD(bool obj)
    {
        livesObject.SetActive(obj);
        energyBarObject.SetActive(obj);
        coinsObject.SetActive(obj);
        timerObject.SetActive(obj);
    }
}
