using UnityEngine;

[CreateAssetMenu(fileName = "NewPlant", menuName = "Plant")]
public class Plant : ScriptableObject
{
    public string plantName;
    public GameObject plantPrefab;
    public float spawnRate;
}
