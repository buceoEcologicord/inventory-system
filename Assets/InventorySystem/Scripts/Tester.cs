using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private ItemsCollection potionsCollection;
    [SerializeField] private Item potionItem;
    [SerializeField] private Item potionItem2;
    [SerializeField] private Item potionItem3;
    void Start()
    {
        potionsCollection.itemsCollection.Add(potionItem);
        potionsCollection.itemsCollection.Add(potionItem2);
        potionsCollection.itemsCollection.Add(potionItem3);
    }

}
