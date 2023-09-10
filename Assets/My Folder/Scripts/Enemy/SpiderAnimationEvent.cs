using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    private Spider m_spider;

    private void Start()
    {
        m_spider = transform.parent.GetComponent<Spider>();
    }
    public void Fire()
    {
        m_spider.Attack();
    }
}
