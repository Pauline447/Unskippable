using UnityEngine;

public class DemonBehaviour : MonoBehaviour
{
    [SerializeField] private int m_randIdleRange;
    protected Animator m_anim;
    private void Start()
    {
        m_anim = GetComponent<Animator>();
    }
    public void AnimationEventSetNewRandomIdle()
    {
        int rand = Random.Range(1, m_randIdleRange);
        m_anim.SetInteger("randIdle", rand);
    }
}
