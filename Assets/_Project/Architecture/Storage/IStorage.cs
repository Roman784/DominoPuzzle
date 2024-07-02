using System;

public abstract class Storage
{
    public abstract GameData GameData { get; protected set; }
    public abstract void Save(Action callback = null);
    public abstract void Load(Action callback = null);

    public void SetVolume(float volume)
    {
        GameData.Audio.Volume = volume;
        Save();
    }
}
