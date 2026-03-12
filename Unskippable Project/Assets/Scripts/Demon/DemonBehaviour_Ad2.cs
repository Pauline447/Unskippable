using UnityEngine;

public class DemonBehaviour_Ad2 : DemonBehaviour
{
    [SerializeField] private GameObject m_skipButton;
    private void Awake()
    {
        SetAnimRange(3);
    }
    public void SetHolyWaterTrue()
    {
        m_anim.SetBool("holyWater", true);
    }

    public void AnimEventSetStartDrinkingTrue()
    {
        m_anim.SetBool("startDrinking", true);
    }
    public void SetSkipButtonActive()
    {
        m_skipButton.SetActive(true);
        m_skipButton.GetComponent<SkipButtonBehaviour>().ButtonClickable = true;
    }
}
