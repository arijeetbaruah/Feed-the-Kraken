using Baruah;
using Baruah.Service;

public interface ICharacterCard
{
    string ID { get; }
    void Execute();
}

public class GunslingerCharacterCard : ICharacterCard
{
    public string ID => "Gunslinger";

    public void Execute()
    {
        ServiceManager.Get<PlayerService>().CurrentPlayer.TotalGuns += 2;
    }
}

public class KleptomaniacCharacterCard : ICharacterCard
{
    public string ID => "Kleptomaniac";

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}

public class TroublemakerCharacterCard : ICharacterCard
{
    public string ID => "Troublemaker";

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}

public class GunsmithCharacterCard : ICharacterCard
{
    public string ID => "Gunsmith";

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}

public class PeacemakerCharacterCard : ICharacterCard
{
    public string ID => "Peacemaker";

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}
