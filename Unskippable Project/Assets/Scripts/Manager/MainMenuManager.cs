using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private float m_speedCutsceneCursor;
    [SerializeField] private Transform m_targetCutsceneCursor;
    [SerializeField] private GameObject m_fullScreen;
    private PlayerController m_player;

    private bool m_startCutscene;
    public bool StartCutscene { get => m_startCutscene; set => m_startCutscene = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_player = PlayerController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(StartCutscene)
        {
            m_player.transform.position = Vector3.MoveTowards(
               m_player.transform.position,
               m_targetCutsceneCursor.position,
               m_speedCutsceneCursor * Time.deltaTime
           );
        }

        float distanceBetweenPos = Vector3.Distance(m_player.transform.position, m_targetCutsceneCursor.position);

        if (distanceBetweenPos < 0.2f)
        {
            PlayerController.Instance.PlayerInControl = true;
            StartCoroutine(LoadFullScreenBeforeStart());
        }
    }

    private IEnumerator LoadFullScreenBeforeStart()
    {
        m_fullScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
