using System;
using System.IO;
using YamlDotNet.Serialization;

internal class Config
{
    public AudioData AudioData { get; set; }
    public SensitivityData SensitivityData { get; set; }
    public GraphicsData GraphicsData { get; set; }
    public bool CreateEndingSaves { get; set; }

    public Config()
    {
        AudioData = new AudioData()
        {
            MusicVol = 0.3,
            SfxVol = 0.3,
        };

        SensitivityData = new SensitivityData()
        {
            Sensitivity = .5,
        };

        GraphicsData = new GraphicsData()
        {
            MobilePerformanceMode = false,
            CurResolution = new CurResolution()
            {
                X = 1920,
                Y = 1080,
            },
            CurRefreshRate = 60,
            Fullscreen = true,
            GraphicsQuality = GraphicsQuality.High
        };

        CreateEndingSaves = false;
    }

    /// <summary>
    /// Load `config.yml`.
    /// Returns `null` if failed. 
    /// </summary>
    /// <param name="config_path"></param>
    /// <returns></returns>
    internal static Config Load(string config_path)
    {
        try
        {
            using (var config_file = new StreamReader(config_path))
            {
                var deserializer = new Deserializer();
                Config config    = deserializer.Deserialize<Config>(config_file);

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
        return $@"{{""audioData"": {AudioData},"
             + $@"""sensitivityData"": {SensitivityData},"
             + $@"""graphicsData"": {GraphicsData}}}";
    }

    internal void SaveAsYaml(string path)
    {
        using (var config_file = new StreamWriter(path))
        {
            var serializer = new Serializer();
            var yaml = serializer.Serialize(this);

            config_file.Write(yaml);
        };
    }
}

internal class AudioData
{
    public double MusicVol { get; set; }
    public double SfxVol { get; set; }

    override public string ToString()
    {
        return $@"{{""musicVol"": {MusicVol}, "
             + $@"""sfxVol"": {SfxVol}}}";
    }
}

internal class SensitivityData
{
    public double Sensitivity { get; set; }

    override public string ToString()
    {
        return $@"{{""sensitivity"": {Sensitivity}}}";
    }
}

internal class GraphicsData
{
    public bool MobilePerformanceMode { get; set; }
    public CurResolution CurResolution { get; set; }
    public int CurRefreshRate { get; set; }
    public bool Fullscreen { get; set; }
    public GraphicsQuality GraphicsQuality { get; set; }

    override public string ToString()
    {
        return $@"{{""mobilePerformanceMode"": {MobilePerformanceMode.ToString().ToLower()},"
             + $@"""curResolution"": {CurResolution},"
             + $@"""curRefreshRate"": {CurRefreshRate},"
             + $@"""fullscreen"": {Fullscreen.ToString().ToLower()},"
             + $@"""graphicsQuality"": {(int)GraphicsQuality}}}";
    }
}

internal class CurResolution
{
    public int X { get; set; }
    public int Y { get; set; }

    override public string ToString()
    {
        return $@"{{""x"": {X}, ""y"": {Y}}}";
    }
}


public enum GraphicsQuality
{
    Low,
    Middle,
    High,
}
