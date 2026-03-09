using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_screens;
    private int m_currentScreen = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    #region Singelton
    private static AdManager instance;
    public static AdManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("AdManager is null");
            }

            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one PlayerController in the scnene!");
        }

        instance = this;
    }
    #endregion
    public void StartNextAd()
    {
        if(m_currentScreen==m_screens.Count)
        {
            Debug.Log("No more screens");
            return;
        }

        m_currentScreen++;
        for (int i = 0; i< m_screens.Count; i++)
        {
           m_screens[i].SetActive(false);
        }
        m_screens[m_currentScreen].SetActive(true);
    }
}
