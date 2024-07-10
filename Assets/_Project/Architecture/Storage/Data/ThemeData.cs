using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class ThemeData
{
    public int CurrentThemeId;
    public List<ThemeStateData> ThemeStates = new List<ThemeStateData>();

    public ThemeStateData ThemeState(int id) => ThemeStates.FirstOrDefault(t => t.Id == id);
}

[System.Serializable]
public class ThemeStateData
{
    public int Id;
    public bool IsUnlocked;
}
