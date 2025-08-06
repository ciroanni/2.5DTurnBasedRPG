using UnityEngine;

[CreateAssetMenu(fileName = "PartyMemberInfo", menuName = "ScriptableObjects/PartyMemberInfo", order = 1)]
public class PartyMemberInfo : ScriptableObject
{
    public string memberName;
    public int startingLevel;
    public int BaseHealth;
    public int BaseStr;
    public int BaseInitiative;
    public GameObject memberPrefab; // what will be instantiated in the overworld scene
    public GameObject memberBattlePrefab; // what will be instantiated in the battle scene

}
