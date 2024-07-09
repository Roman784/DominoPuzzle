using System;
using UnityEngine;
using Zenject;

public abstract class Storage
{
    public abstract GameData GameData { get; protected set; }
    public abstract void Save(Action callback = null);
    public abstract void Load(Action callback = null);

    private DefaultGameData _defaultData;

    [Inject]
    private void Construct(DefaultGameData defaultData)
    {
        _defaultData = defaultData;
    }

    public void DefaultData()
    {
        GameData = _defaultData.GameData;
        Save();
    }

    public void SetLastCompletedLevelNumber(int number)
    {
        GameData.Level.LastCompletedLevelNumber = number;
        Save();
    }

    public void SetVolume(float volume)
    {
        GameData.Audio.Volume = volume;
        Save();
    }
}
