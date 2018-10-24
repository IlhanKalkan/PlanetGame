using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Interactables/Building")]
public class Building : Interactable {

    public Recipe recipe;
    public string Description;
    public MeshRenderer mr;
}
