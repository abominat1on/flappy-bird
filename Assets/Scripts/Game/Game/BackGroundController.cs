using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [System.Serializable]
    public class BgSettings
    {
        public Renderer[] Background;
        public float[] Speed = { 0, 0.001f, 0.005f};
    }

    [SerializeField] private Rigidbody2D player = null;
    [SerializeField] private BgSettings[] bgSettings = null;
    private BgSettings curBg = null;
    private static int curBgIndex = 0;
    private Vector3 prevPlayerPos;

    float x;

    private void Start()
    {
        curBg = bgSettings[curBgIndex];


        for (int i = 0; i < bgSettings.Length; i++)
        {
            foreach (var item in bgSettings[i].Background)
            {
                item.gameObject.SetActive(i == curBgIndex);
            }
        }

        curBgIndex++;
        if (curBgIndex >= bgSettings.Length)
        {
            curBgIndex = 0;
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - prevPlayerPos).normalized;
            x += direction.x * Time.deltaTime;

            for (int i = 0; i < curBg.Background.Length; i++)
            {
                var selectedBg = curBg.Background;
                var offset = (x * curBg.Speed[i]) % 1;
                selectedBg[i].material.mainTextureOffset = new Vector2(offset, selectedBg[i].material.mainTextureOffset.y);
            }
            prevPlayerPos = player.transform.position;
        }
    }
}
