using UnityEngine;
using System.Collections.Generic;

public class PartyManager : MonoBehaviour
{
    [SerializeField]
    private List<Character> selectChars = new List<Character>();
    public List<Character> SelectChars { get { return selectChars; } }

    [SerializeField]
    private List<Character> members = new List<Character>();
    public List<Character> Members { get { return members; } }

    public static PartyManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        foreach (Character c in members)
        {
            c.charInit(VFXManager.instance, UIManager.instance);
        }
        SelectSingleHero(0);

        // Hero 1
        members[0].MagicSkills.Add(new Magic(VFXManager.instance.MagicData[0]));

        // Hero 2
        members[1].MagicSkills.Add(new Magic(VFXManager.instance.MagicData[1]));

        InventoryManager.instance.AddItem(members[0], 0);
        InventoryManager.instance.AddItem(members[0], 1);
        InventoryManager.instance.AddItem(members[0], 3);
        InventoryManager.instance.AddItem(members[0], 6);
        InventoryManager.instance.AddItem(members[0], 9);

        InventoryManager.instance.AddItem(members[1], 2);
        InventoryManager.instance.AddItem(members[1], 4);
        InventoryManager.instance.AddItem(members[1], 6);
        InventoryManager.instance.AddItem(members[1], 8);
        InventoryManager.instance.AddItem(members[1], 7);

        UIManager.instance.ShowMagicToggles();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (selectChars.Count > 0)
            {
                selectChars[0].IsMagicMode = true;
                selectChars[0].CurMagicCast = selectChars[0].MagicSkills[0];
            }
        }
    }

    public void SelectSingleHero(int i)
    {
        foreach (Character c in selectChars)
            c.ToggleRingSelection(false);

        selectChars.Clear();

        selectChars.Add(members[i]);
        selectChars[0].ToggleRingSelection(true);
    }

    public void HeroSelectMagicSkill(int i)
    {
        if (selectChars.Count <= 0)
            return;

        selectChars[0].IsMagicMode = true;
        selectChars[0].CurMagicCast = selectChars[0].MagicSkills[i];
    }


}