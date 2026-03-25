using UnityEngine;

public enum FoodType
{
    Nugget,
    Burger,
    Fries
}
public class FallingObject : MonoBehaviour
{
    [SerializeField] private FoodType m_type;

    private AdBehaviour_Screen04 m_screen;

    public AdBehaviour_Screen04 Screen { get => m_screen; set => m_screen = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.y < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    public void AddFood()
    {
        Screen.AddItemToFoodList(m_type);
        Destroy(this.gameObject);
    }
}
