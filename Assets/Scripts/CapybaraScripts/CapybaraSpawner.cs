using UnityEngine;
using YG;
using Random = UnityEngine.Random;

public class CapybaraSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject capybaraPrefab;

    [SerializeField]
    private Sprite[] capybaraSprites;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += InitCapybaraLevel;
        LevelMananger.OnLevelUp += SpawnNewCapybara;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= InitCapybaraLevel;
        LevelMananger.OnLevelUp -= SpawnNewCapybara;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            InitCapybaraLevel();
        }
    }

    private void SpawnCapybaras(int capybaraLevel)
    {
        var spawnedCapyara = 1;
        while (spawnedCapyara < capybaraLevel)
        {
            SpawnNewCapybara(++spawnedCapyara);
        }
    }

    private void InitCapybaraLevel()
    {
        SpawnCapybaras(YandexGame.savesData.capybaraLevel);
    }

    private void SpawnNewCapybara(int level)
    {
        if (level <= capybaraSprites.Length)
        {
            var spawnedCapybara = Instantiate(capybaraPrefab, new Vector3(Random.Range(-6f, 3f), Random.Range(-2f, -1f), 0), Quaternion.identity);
            spawnedCapybara.GetComponent<SpriteRenderer>().sprite = capybaraSprites[level - 1];
        }
    }
}
