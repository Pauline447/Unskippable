using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdBehaviour_Screen04 : AdBehaviour
{
    [SerializeField] private Animator m_animGiftBag;
    private List<FoodType> m_foodItemList;
    private void Start()
    {
        m_foodItemList = new List<FoodType>();
    }
    protected override IEnumerator AppearingRoutine()
    {
        int rand = Random.Range(0, 3);
        MakeAppear(rand);
        yield return new WaitForSeconds(1f);

        StopCoroutine(m_appearingRoutine);
        m_appearingRoutine = StartCoroutine(AppearingRoutine());
    }

    public override void MakeAppear(int reviewInt)
    {
        GameObject review = Instantiate(m_Prefabs[reviewInt], m_parent);

        int randX = Random.Range(-9, 9);
        review.transform.position = new Vector3(randX, m_Pos[0].position.y);

        review.GetComponent<FallingObject>().Screen = this;
    }

    public void AddItemToFoodList(FoodType type)
    {
        m_foodItemList.Add(type);
        CheckList();
    }

    private void CheckList()
    {
        for (int i = 0; i < m_foodItemList.Count; i++)
        {
            switch(i)
            {
                case 0:
                    if (m_foodItemList[0] != FoodType.Nugget)
                    {
                        m_foodItemList.Clear();
                    }
                    break;
                case 1:
                    if (m_foodItemList[1] != FoodType.Burger)
                    {
                        m_foodItemList.Clear();
                    }
                    break;
                case 2:
                    if (m_foodItemList[2] != FoodType.Burger)
                    {
                        m_foodItemList.Clear();
                    }
                    break;
                case 3:
                    if (m_foodItemList[3] != FoodType.Fries)
                    {
                        m_foodItemList.Clear();
                    }
                    break;
                case 4:
                    if (m_foodItemList[4] != FoodType.Nugget)
                    {
                        m_foodItemList.Clear();
                    }
                    else
                        m_animGiftBag.Play("GiftBagWon");
                    break;
            }
        }
       
     
    }

}
