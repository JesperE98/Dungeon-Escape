using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public abstract class AudioManager : MonoBehaviour
{
    [SerializeField]
    protected EventReference AttackEvent;
    [SerializeField]
    protected EventReference HitEvent;
    [SerializeField]
    protected EventReference WalkEvent;
    [SerializeField]
    protected EventReference DeathEvent;


    FMOD.Studio.EventInstance FMODeventInstance;
}
