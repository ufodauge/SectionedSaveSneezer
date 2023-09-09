using System.Collections.Generic;
using System.IO;
using System.Text;

internal class SaveData
{
    private readonly int checkPoint;
    private readonly bool storyModeCompleted;

    private readonly List<StoredData> storedDatas;

    public SaveData(int check_point)
    {
        checkPoint = check_point;
        storyModeCompleted = false;

        storedDatas = new List<StoredData>()
        {
            new StoredData()
            {
                identifier = @"""Story Progess""",
                serialized = $@"""{{\""lastCheckpoint\"":{checkPoint}}}"""
            },
            new StoredData()
            {
                identifier = @"""Liberation Progress""",
                serialized = $@"""{{\""animalStates\"":[{{\""type\"":4,\""state\"":1,\""numFreed\"":0,\""numToFree\"":10}},{{\""type\"":1,\""state\"":1,\""numFreed\"":0,\""numToFree\"":10}},{{\""type\"":64,\""state\"":1,\""numFreed\"":0,\""numToFree\"":10}},{{\""type\"":2,\""state\"":1,\""numFreed\"":0,\""numToFree\"":10}},{{\""type\"":256,\""state\"":1,\""numFreed\"":0,\""numToFree\"":10}},{{\""type\"":16,\""state\"":1,\""numFreed\"":0,\""numToFree\"":10}},{{\""type\"":128,\""state\"":1,\""numFreed\"":0,\""numToFree\"":10}},{{\""type\"":512,\""state\"":1,\""numFreed\"":0,\""numToFree\"":10}},{{\""type\"":8,\""state\"":1,\""numFreed\"":0,\""numToFree\"":10}},{{\""type\"":32,\""state\"":1,\""numFreed\"":0,\""numToFree\"":10}}],\""usedSpawnPoints\"":[]}}"""
            },
            new StoredData()
            {
                identifier = @"""Gameplay Data""",
                serialized = $@"""{{\""storyModeCompleted\"":{storyModeCompleted},\""liberationModeCompleted\"":false}}"""
            },
            new StoredData()
            {
                identifier = @"""Language Data""",
                serialized = $@"""{{\""currentLanguage\"":320}}"""
            },
            new StoredData()
            {
                identifier = @"""Hint Data""",
                serialized = $@"""{{\""hintShownCounts\"":{{\""keys\"":[],\""values\"":[]}},\""lastHintShown\"":\""InvalidHint\"",\""penaltyPopupsShown\"":0,\""penaltyHistory\"":[false,false,false,false,false,false,false,false,false,false],\""penaltyHistoryNextIdx\"":0}}"""
            },
            new StoredData()
            {
                identifier = @"""Achievements Data""",
                serialized = $@"""{{\""numDoubleBackflips\"":0,\""numPairThrows\"":0,\""throwFlip\"":false,\""sameVine\"":false,\""fiveBounce\"":false,\""backflipSlide\"":false,\""canabalt\"":false,\""drop\"":false}}"""
            },
            new StoredData()
            {
                identifier = @"""RestartManager Data""",
                serialized = $@"""{{\""creditsShown\"":false,\""liberationEndShown\"":false}}"""
            },
        };
    }
    internal void CreateFileWith(string path)
    {
        using (var save_data_file = new StreamWriter(path)) { 
            save_data_file.Write(ToString());
        };
    }

    override public string ToString()
    {
        var builder = new StringBuilder();
        builder.Append('[');
        builder.Append(string.Join(",", storedDatas));
        builder.Append(']');

        return $@"{{""storedData"": ["
             + builder
             + $@"]}}";
    }
}

internal class StoredData
{
    public string identifier;
    public string serialized;

    override public string ToString()
    {
        return $@"{{""identifier"": {identifier}, "
             + $@"""serialized"": {serialized}}}";
    }
}