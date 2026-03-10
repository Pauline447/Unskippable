using UnityEngine;

public class DemonBehaviour_Ad2 : MonoBehaviour
{
    private Animator m_anim;
    private void Start()
    {
        m_anim = GetComponent<Animator>();
    }
    public void AnimationEventSetNewRandomIdle()
    {
        int rand = Random.Range(1, 3);
        Debug.Log("Rand" + rand);
        m_anim.SetInteger("randIdle", rand);
    }
}
