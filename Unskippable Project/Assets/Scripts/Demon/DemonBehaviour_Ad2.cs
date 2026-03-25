using UnityEngine;

public class DemonBehaviour_Ad2 : DemonBehaviour
{
    [SerializeField] private GameObject m_skipButton;
    [SerializeField] private GameObject m_bottle;

    public void SetHolyWaterTrue()
    {
        m_anim.SetBool("holyWater", true);
    }

    public void AnimEventSetStartDrinkingTrue()
    {
        m_anim.SetBool("startDrinking", true);
    }
    public void AnimationEventDeactivateBottle()
    {
        m_bottle.SetActive(false);
    }
    public void AnimationEventActivateBottle()
    {
        m_bottle.SetActive(true);
    }
    public void SetSkipButtonActive()
    {
        m_skipButton.SetActive(true);
        m_skipButton.GetComponent<SkipButtonBehaviour>().ButtonClickable = true;
    }
}
