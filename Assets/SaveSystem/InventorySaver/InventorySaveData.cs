using System;
using System.Collections.Generic;

[Serializable]
public class InventorySaveData
{
    public List<string> itemNames = new List<string>();
    public Dictionary<string, int> countStack = new Dictionary<string, int>();
}
