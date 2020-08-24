using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Bulldozer Config", menuName = "Create BullDozer Config")]
public class BullDozerConfig : BaseConfig
{
    [SerializeField]
    private float _animationSpeed;
    public float AnimationSpeed => _animationSpeed;

}