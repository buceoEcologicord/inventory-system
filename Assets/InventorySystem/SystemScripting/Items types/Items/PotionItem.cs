using UnityEngine;

[CreateAssetMenu(fileName = "PotionItem", menuName = "Items/Potion")]
public class PotionItem : Item
{
    [SerializeField] public int healAmount;
    [SerializeField] public bool maxHeal;

}
