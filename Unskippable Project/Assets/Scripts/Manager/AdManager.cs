using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_screens;
    [SerializeField] private List<GameObject> m_screenUIs;
    [SerializeField] private GameObject m_skipTimer;
    public int m_currentScreen = 0; //Debug
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject SkipTimer { get => m_skipTimer; set => m_skipTimer = value; }

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

    private void Start()
    {
        for (int i = 0; i < m_screens.Count; i++)
        {
            m_screens[i].SetActive(false);
            m_screenUIs[i].SetActive(false);
        }
        m_screens[m_currentScreen].SetActive(true);
        m_screenUIs[m_currentScreen].SetActive(true);
    }
    public void StartNextAd()
    {
        if(m_currentScreen==m_screens.Count -1)
        {
            Debug.Log("No more screens");
            return;
        }

        m_currentScreen++;
        for (int i = 0; i< m_screens.Count; i++)
        {
           m_screens[i].SetActive(false);
           m_screenUIs[i].SetActive(false);
        }
        m_screens[m_currentScreen].SetActive(true);
        m_screenUIs[m_currentScreen].SetActive(true);

    }
}
