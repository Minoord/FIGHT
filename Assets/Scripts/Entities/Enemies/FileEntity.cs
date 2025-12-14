
public class FileEntity : Enemy
{
    protected override void OnDeSpawned()
    {
        base.OnDeSpawned();
        UnityEngine.Application.Quit();
    }
}
