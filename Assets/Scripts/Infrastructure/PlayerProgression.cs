using UnityEngine;

public class PlayerProgression
{
    private const string LevelIndex = "LevelIndex";
    private int _currentLevelIndex;

    public void SetNextLevel()
    {
        _currentLevelIndex++;
        PlayerPrefs.SetInt(LevelIndex, _currentLevelIndex);
    }
    
    public void ChangeIndexAndSave(int index)
    {
        _currentLevelIndex = index;
        PlayerPrefs.SetInt(LevelIndex, _currentLevelIndex);
    }

    public int LoadIndex() => 
        _currentLevelIndex = PlayerPrefs.HasKey(LevelIndex) ? PlayerPrefs.GetInt(LevelIndex) : 0;
}