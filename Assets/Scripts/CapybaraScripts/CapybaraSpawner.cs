using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CapybaraSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject capybaraPrefab;

    [SerializeField]
    private Sprite[] capybaraSprites;
    private void Start()
    {
        LevelMananger.OnLevelUp += SpawnNewCapybara;
        SpawnCapybaras();
    }

    private void SpawnCapybaras()
    {
        var capybaraLevel = PlayerPrefs.GetInt("CapybaraLevel", 1);
        var spawnedCapyara = 1;
        while (spawnedCapyara < capybaraLevel)
        {
            SpawnNewCapybara(++spawnedCapyara);
        }
    }

    private void SpawnNewCapybara(int level)
    {
        if (level <= capybaraSprites.Length)
        {
            var spawnedCapybara = Instantiate(capybaraPrefab, new Vector3(Random.Range(-6f, 3f) , Random.Range(-2f, -1f), 0), Quaternion.identity);
            spawnedCapybara.GetComponent<SpriteRenderer>().sprite = capybaraSprites[level - 1];
        }
    }
}
