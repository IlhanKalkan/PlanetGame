using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipes/BuildingRecipe")]
public class Recipe : ScriptableObject {

    public List<Resource> requiredResources;
    public Dictionary<Resource, int> requiredAmounts;
    public Building result;
}
