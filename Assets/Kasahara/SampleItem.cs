using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleItem : ItemBase
{
    /// <summary>プレイヤーを消します</summary>
    public override void Activate()
    {
        Destroy(Player);
    }
}
