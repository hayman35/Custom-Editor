using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CharacterData", menuName = "Custom Unity Editor/CharacterData", order = 0)]
public class CharacterData : ScriptableObject {
    public GameObject prefab;
    public float maxHealth;
    public float maxEnergy;
    public float critChance;
    public float power;
    public string name;
    
}

