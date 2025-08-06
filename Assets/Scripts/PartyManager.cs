using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    [SerializeField] private PartyMemberInfo[] partyMembers; // Array of party members
    [SerializeField] private List<PartyMember> currentParty;
    [SerializeField] private PartyMemberInfo defaultMember; // Default member to add if no specific member is found
    private void Awake()
    {
        AddMemberToPartyByName(defaultMember.memberName);
    }
    public void AddMemberToPartyByName(string memberName)
    {
        for (int i = 0; i < partyMembers.Length; i++)
        {
            if (partyMembers[i].memberName == memberName)
            {
                PartyMember newMember = new PartyMember();
                newMember.MemberName = partyMembers[i].memberName;
                newMember.Level = partyMembers[i].startingLevel;
                newMember.CurrHealth = partyMembers[i].BaseHealth;
                newMember.MaxHealth = partyMembers[i].BaseHealth;
                newMember.Strength = partyMembers[i].BaseStr;
                newMember.Initiative = partyMembers[i].BaseInitiative;
                newMember.MemberPrefab = partyMembers[i].memberPrefab;
                newMember.MemberBattlePrefab = partyMembers[i].memberBattlePrefab;

                currentParty.Add(newMember);
            }
        }
    }
}

[System.Serializable]
public class PartyMember
{
    public string MemberName;
    public int Level;
    public int CurrHealth;
    public int MaxHealth;
    public int Strength;
    public int Initiative;
    public int CurrExp;
    public int MaxExp;
    public GameObject MemberPrefab;
    public GameObject MemberBattlePrefab;
}
