using System;
using System.IO;
using YamlDotNet.Serialization;

internal class Config
{
    public AudioData audioData;
    public SensitivityData sensitivityData;
    public GraphicsData graphicsData;

    public Config()
    {
        audioData = new AudioData()
        {
            musicVol = 1.0,
            sfxVol = 1.0
        };

        sensitivityData = new SensitivityData()
        {
            sensitivity = .5,
        };

        graphicsData = new GraphicsData()
        {
            mobilePerformanceMode = false,
            curResolution = new CurResolution()
            {
                x = 1920,
                y = 1080,
            },
            curRefreshRate = 60,
            fullscreen = true,
            graphicsQuality = GraphicsQuality.High
        };
    }

    internal static Config Load(string config_path)
    {
        try
        {
            using (var config_file = new StreamReader(config_path))
            {
                var deserializer = new Deserializer();
                Config config = deserializer.Deserialize<Config>(config_file);

                return config;
            };
        }
        catch (Exception)
        {
            return null;
        }
    }

    internal void CreateFileWith(string path)
    {
        using (var config_file = new StreamWriter(path))
        {
            config_file.Write(ToString());
        };
    }

    override public string ToString()
    {
        return $@"{{""audioData"": {audioData},"
             + $@"""sensitivityData"": {sensitivityData},"
             + $@"""graphicsData"": {graphicsData}}}";
    }

    internal void SaveAsYaml(string path)
    {
        using (var config_file = new StreamWriter(path))
        {
            var yaml = new SerializerBuilder()
                .Build()
                .Serialize(this);

            config_file.Write(yaml);
        };
    }
}

internal class AudioData
{
    public double musicVol;
    public double sfxVol;

    override public string ToString()
    {
        return $@"{{""musicVol"": {musicVol}, "
             + $@"""sfxVol"": {sfxVol}}}";
    }
}

internal class SensitivityData
{
    public double sensitivity;

    override public string ToString()
    {
        return $@"{{""sensitivity"": {sensitivity}}}";
    }
}

internal class GraphicsData
{
    public bool mobilePerformanceMode;
    public CurResolution curResolution;
    public int curRefreshRate;
    public bool fullscreen;
    public GraphicsQuality graphicsQuality;

    override public string ToString()
    {
        return $@"{{""mobilePerformanceMode"": {mobilePerformanceMode.ToString().ToLower()},"
             + $@"""curResolution"": {curResolution},"
             + $@"""curRefreshRate"": {curRefreshRate},"
             + $@"""fullscreen"": {fullscreen.ToString().ToLower()},"
             + $@"""graphicsQuality"": {(int)graphicsQuality}}}";
    }
}

internal class CurResolution
{
    public int x;
    public int y;

    override public string ToString()
    {
        return $@"{{""x"": {x}, ""y"": {y}}}";
    }
}


public enum GraphicsQuality
{
    Low,
    Middle,
    High,
}
