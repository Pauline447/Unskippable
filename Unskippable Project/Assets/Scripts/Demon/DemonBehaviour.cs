using UnityEngine;

public class DemonBehaviour : MonoBehaviour
{
    protected Animator m_anim;
    protected int m_range;
    private void Start()
    {
        m_anim = GetComponent<Animator>();
    }
    public void AnimationEventSetNewRandomIdle()
    {
        int rand = Random.Range(1, m_range);
        m_anim.SetInteger("randIdle", rand);
    }

    public void SetAnimRange(int range)
    {
        m_range = range;
    }
}
