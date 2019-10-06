using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    private int completeLevels = 5;

    public void Start()
        {
        StartCoroutine(OnGeneratingRoutine());
        }

    private IEnumerator OnGeneratingRoutine()
    {
        int count = this.completeLevels + 5;
        for (int i = 0; i < count; i++)
        {
            Vector2 size = new Vector2(1, 1);
            Vector2 position = new Vector2(0, 0);
            platform.transform.position = position;
            platform.transform.localScale = size;
            position.x += size.x;
            position.y += size.y * Random.Range(-1, 2);
            yield return new WaitForEndOfFrame();
        }
    }

    public void CompleteLevel()
        {
            this.completeLevels += 1;
            StartCoroutine(OnGeneratingRoutine());
        }

    }
