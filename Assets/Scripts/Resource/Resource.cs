using System;
using UnityEngine;

[Serializable]
public struct Resource {
    public string name;
    public int amount;
    public Sprite sprite;

    public Resource(string name, int amount, Sprite sprite)
    {
        this.name = name;
        this.amount = amount;
        this.sprite = sprite;
    }
}
