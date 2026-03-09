using System.Collections;
using UnityEngine;

public class SkipButtonBehaviour_MoveAway : MonoBehaviour
{
    [SerializeField] private float m_maxDistance;
    [SerializeField] private float m_repelSpeed;

    private PlayerController m_player;
    private Vector3 m_playerPos;
    private Vector3 m_direction;

    private bool m_pushbackFromWall = false;

    private Coroutine m_pushBackWallWaitRoutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_player = PlayerController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        m_playerPos = m_player.GetPlayerPos();
        
        float distanceBetweenPosPlayer = Vector3.Distance(transform.position, m_playerPos);

        if(distanceBetweenPosPlayer < m_maxDistance && !m_pushbackFromWall)
        {
            m_direction = (transform.position - m_playerPos).normalized;
            transform.position += m_direction * m_repelSpeed * Time.deltaTime;
        }

        if(m_pushbackFromWall)
        {
            transform.position += m_direction * m_repelSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Vector2 normal = collision.contacts[0].normal;
            m_direction = Vector2.Reflect(m_direction, normal).normalized;
            m_pushbackFromWall = true;

            if(m_pushBackWallWaitRoutine!= null)
            {
                StopCoroutine(m_pushBackWallWaitRoutine);
            }
            m_pushBackWallWaitRoutine = StartCoroutine(PushBackFromWalltimer());
        }
    }

    private IEnumerator PushBackFromWalltimer()
    {
        yield return new WaitForSeconds(0.1f);
        m_pushbackFromWall = false;
    }
}

