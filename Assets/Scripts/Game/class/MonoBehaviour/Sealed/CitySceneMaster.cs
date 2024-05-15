
using System.Collections;

public sealed class CitySceneMaster : SceneMaster
{
    protected override IEnumerator _Opening()
    {
        if (GameMaster.instance.gameInfo.levelInfo == null)
        {
            GameMaster.instance.NewLevelInfo();
        }

        Player.instance.Awaken();

        Player.instance.Launch();

        backgroundMusic = AudioMaster.instance.Pop(AudioClipCode.City_0);

        backgroundMusic.Play(1.5f);

        yield return base._Opening();

        yield return StageMaster.instance.Stage(SceneCode.City);

        yield return CoroutineManager.WaitForSeconds(5f);

        LoadScene(SceneCode.Desert);
    }
}