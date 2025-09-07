using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemname = "New Item";

    public string description = "Description";
    public Sprite icon = null; 
    
}
