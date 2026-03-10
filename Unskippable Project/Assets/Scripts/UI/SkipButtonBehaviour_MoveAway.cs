using System.Collections;
using UnityEngine;

public class SkipButtonBehaviour_MoveAway : SkipButtonBehaviour
{
    [SerializeField] private float m_maxDistance;
    [SerializeField] private float m_repelSpeedValue;

    private float m_repelSpeed;
    private Vector3 m_direction;

    private bool m_pushback = false;


    private Coroutine m_pushBackWaitRoutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        m_player = PlayerController.Instance;
        m_repelSpeed = m_repelSpeedValue;
    }

    // Update is called once per frame
    void Update()
    {
        m_playerPos = m_player.transform.position;

        float distanceBetweenPosPlayer = Vector3.Distance(transform.position, m_playerPos);

        if(distanceBetweenPosPlayer < m_maxDistance && !m_pushback)
        {
            m_direction = (transform.position - m_playerPos).normalized;
            transform.position += m_direction * m_repelSpeed * Time.deltaTime;
        }

        if(m_pushback)
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

            //switch different walls
            switch (collision.gameObject.name)
            {
                case "Left":
                    if (m_direction.x > 0.90)
                    {
                        float y = 0;
                        if(transform.position.y <0)
                        {
                            y = 1f;
                        }
                        else
                        {
                            y = -1f;
                        }
                        m_direction = new Vector2(0f, y);
                    }
                    break;
                case "Right":
                    if (m_direction.x < -0.90)
                    {
                        float y = 0;
                        if (transform.position.y < 0)
                        {
                            y = 1f;
                        }
                        else
                        {
                            y = -1f;
                        }
                        m_direction = new Vector2(0f, y);
                    }
                    break;
                case "Up":
                    if (m_direction.y < -0.90)
                    {
                        float x = 0;
                        if (transform.position.x < 0)
                        {
                            x = 1f;
                        }
                        else
                        {
                            x = -1f;
                        }
                        m_direction = new Vector2(x, -0f);
                    }
                    break;
                case "Down":
                    if (m_direction.y > 0.90)
                    {
                        float x = 0;
                        if (transform.position.x < 0)
                        {
                            x = 1f;
                        }
                        else
                        {
                            x = -1f;
                        }
                        m_direction = new Vector2(x, 0f);
                    }
                    break;
            }

            m_pushback = true;

            if(m_pushBackWaitRoutine!= null)
            {
                StopCoroutine(m_pushBackWaitRoutine);
            }
            m_pushBackWaitRoutine = StartCoroutine(PushBackTimer(0.1f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sticky")
        {
            m_repelSpeed = 0.7f;
            ButtonClickable = true;
            PlayerController.Instance.GetComponent<Collider2D>().enabled = false;
        }
        if (collision.gameObject.tag == "Fast")
        {
            m_repelSpeed = 70f;
            m_pushback = true;

            if (m_pushBackWaitRoutine != null)
            {
                StopCoroutine(m_pushBackWaitRoutine);
            }
            m_pushBackWaitRoutine = StartCoroutine(PushBackTimer(0.3f));
        }
        if(collision.gameObject.tag == "Color")
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.blue;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sticky" || collision.gameObject.tag == "Fast")
        {
            m_repelSpeed = m_repelSpeedValue;
            ButtonClickable = false;
            PlayerController.Instance.GetComponent<Collider2D>().enabled = true;
        }
    }

    private IEnumerator PushBackTimer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        m_pushback = false;
    }
}

