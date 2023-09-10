using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

internal class Profile
{
    private readonly Guid guid;
    private readonly long created;
    private readonly long lastPlayed;

    public Profile(Guid guid, long created, long lastPlayed)
    {
        this.guid = guid;
        this.created = created;
        this.lastPlayed = lastPlayed;
    }

    public override string ToString()
    {
        return "{"
            + $@"""id"": ""{guid}"", "
            + $@"""created"": {created}, "
            + $@"""lastPlayed"": {lastPlayed}, "
            + $@"""playTime"": {0}, "
            + $@"""isValid"": true, "
            + $@"""syncState"": {(int)SyncState.Synced}"
            + "}";
    }
}

enum SyncState
{
    None,
    Synced,
    Disposed,
}

internal class ProfileList
{
    private readonly List<Profile> profiles;

    public ProfileList()
    {
        profiles = new List<Profile>();
    }

    public ProfileList Add(Profile profile)
    {
        profiles.Add(profile);

        return this;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.Append(@"{""storedData"":[],""profiles"":");
        builder.Append($"[{string.Join(",", profiles)}]");
        builder.Append('}');

        return builder.ToString();
    }

    internal void CreateFileWith(string path)
    {
        using (var save_data_file = new StreamWriter(path))
        {
            save_data_file.Write(ToString());
        };
    }
}