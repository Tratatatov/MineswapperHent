using HentaiGame;

public class LevelBootstrapper : IBootstrapper
{
    private LevelInstaller _installer;

    public LevelBootstrapper(LevelInstaller installer)
    {
        _installer = installer;
    }

    public void InitializeAllServices()
    {

    }
}


