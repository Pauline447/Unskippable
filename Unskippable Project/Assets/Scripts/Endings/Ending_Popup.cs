using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_Popup : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_popUpPrefabs;
    [SerializeField] private RectTransform m_parent;
    [SerializeField] UI_SpeedrunTimer m_speedrunTimer;

    private float m_timeBetweenSpawn = 0.2f;
    #region Singelton
    private static Ending_Popup instance;
    public static Ending_Popup Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Ending_Popup is null");
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
        m_speedrunTimer.StopTimer();
        StartCoroutine(StartSpawnCoroutine());
    }

    private IEnumerator StartSpawnCoroutine()
    {
        yield return new WaitForSeconds(2f);
        SpawnPopup();
        yield return new WaitForSeconds(m_timeBetweenSpawn);
        SpawnPopup();
        yield return new WaitForSeconds(m_timeBetweenSpawn);
        SpawnPopup();
        yield return new WaitForSeconds(m_timeBetweenSpawn);
        SpawnPopup();
        yield return new WaitForSeconds(m_timeBetweenSpawn);
        SpawnPopup();
        yield return new WaitForSeconds(m_timeBetweenSpawn);
        SpawnPopup();
        yield return new WaitForSeconds(m_timeBetweenSpawn);
        SpawnPopup();
        yield return new WaitForSeconds(m_timeBetweenSpawn);
        SpawnPopup();
        yield return new WaitForSeconds(m_timeBetweenSpawn);
        SpawnPopup();
        yield return new WaitForSeconds(m_timeBetweenSpawn);
        SpawnPopup();
        yield return new WaitForSeconds(m_timeBetweenSpawn);
        SpawnPopup();
    }
    public void SpawnPopup()
    {
        int randPopUp = Random.Range(0,m_popUpPrefabs.Count);
        GameObject popup = Instantiate(m_popUpPrefabs[randPopUp], m_parent);
        RectTransform popupRect = popup.GetComponent<RectTransform>();

        float x = Random.Range(-m_parent.rect.width / 2f, m_parent.rect.width / 2f);
        float y = Random.Range(-m_parent.rect.height / 2f, m_parent.rect.height / 2f);

        popupRect.anchoredPosition = new Vector2(x, y);

        if(randPopUp == 0)
        {
            popup.GetComponent<UI_Popup>().Text.text = m_speedrunTimer.CurrentTime;
        }
    }
}
