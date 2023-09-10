using System;
using System.IO;

internal class MetaConfig
{
    public Guid currentProfile;
    public GraphicsDeviceData graphicsDeviceData = new GraphicsDeviceData();
    public RestartDataLocal restartDataLocal = new RestartDataLocal();

    public MetaConfig(Guid currentProfile)
    {
        this.currentProfile = currentProfile;
    }

    public override string ToString()
    {
        return "{"
            + $"\"currentProfile\": \"{currentProfile}\", "
            + $"\"graphicsDeviceData\": {graphicsDeviceData}, "
            + $"\"restartDataLocal\": {restartDataLocal}"
            + "}";
    }

    internal void CreateFileWith(string path)
    {
        using (var save_data_file = new StreamWriter(path))
        {
            save_data_file.Write(ToString());
        };
    }
}

internal class GraphicsDeviceData
{
    public NativeResolution nativeResolution = new NativeResolution();
    public int nativeRefreshRate = 60;

    public override string ToString()
    {
        return "{"
            + $"\"nativeResolution\": {nativeResolution}, "
            + $"\"nativeRefreshRate\": {nativeRefreshRate}"
            + "}";
    }
}

internal class NativeResolution
{
    public int x = 1920;
    public int y = 1080;
    public override string ToString()
    {
        return $"{{\"x\": {x}, \"y\": {y}}}";
    }
}

internal class RestartDataLocal
{
    public bool splashScreensShown = true;
    public int numFailsOnRestart   = 0;

    public override string ToString()
    {
        return "{"
            + $"\"splashScreensShown\": {splashScreensShown.ToString().ToLower()}, "
            + $"\"numFailsOnRestart\": {numFailsOnRestart}"
            + "}";
    }
}
