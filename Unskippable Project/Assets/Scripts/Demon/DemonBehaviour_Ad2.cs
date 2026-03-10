using UnityEngine;

public class DemonBehaviour_Ad2 : MonoBehaviour
{
    [SerializeField] private GameObject m_skipButton;
    private Animator m_anim;
    private void Start()
    {
        m_anim = GetComponent<Animator>();
    }
    public void AnimationEventSetNewRandomIdle()
    {
        int rand = Random.Range(1, 3);
        m_anim.SetInteger("randIdle", rand);
    }

    public void SetHolyWaterTrue()
    {
        m_anim.SetBool("holyWater", true);
    }
    public void SetSkipButtonActive()
    {
        m_skipButton.SetActive(true);
        m_skipButton.GetComponent<SkipButtonBehaviour>().ButtonClickable = true;
    }
}
