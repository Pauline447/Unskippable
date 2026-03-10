using UnityEngine;

public class DemonBehaviour : MonoBehaviour
{
    protected Animator m_anim;
    private void Start()
    {
        m_anim = GetComponent<Animator>();
    }
    public void AnimationEventSetNewRandomIdle()
    {
        int rand = Random.Range(1, 3);
        m_anim.SetInteger("randIdle", rand);
    }
}
