using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;


namespace Arachnid
{

    public class Destructible : MonoBehaviour, IDestructible
    {
        [ToggleLeft]
        public bool invincible;

        public float initInvincible;

        [OnValueChanged("UpdateHP", true)]
        public FloatReference hp;

        [ReadOnly]
        public float hpCurrent = 5;
        void UpdateHP ()
        {
            if (Application.isPlaying) return;
            hpCurrent = hp.Value;
        }

        [AssetsOnly, FoldoutGroup("Events")]
        public GameEvent onKilledEvent;

        [AssetsOnly, FoldoutGroup("Events")]
        public GameEvent onDamagedEvent;

        [FoldoutGroup("Events")]
        public List<HpEvent> hpEvents = new List<HpEvent>();

        public Action onDamaged;
        public Action onKilled;

        float _invincibleTimer;

        void Awake()
        {
            invincible = true;
            _invincibleTimer = initInvincible;
        }

        // Use this for initialization
        void Start ()
        {
            hpCurrent = hp.Value;
        }

        void Update ()
        {
            if (_invincibleTimer > 0) _invincibleTimer -= Time.deltaTime;
            else invincible = false;
        }

        void DamageEffects (int damage, Vector3 dir, Vector3 pos)
        {
        }

        public void Damage (int damage, Vector3 dir, Vector3 pos)
        {
            if (invincible) return;
            onDamaged?.Invoke();

            hpCurrent -= damage;
            onDamagedEvent?.Raise();

            if (hpCurrent <= 0) Kill();
        }

        public void Kill ()
        {
            onKilledEvent?.Raise();
            onKilled?.Invoke();
            Destroy(gameObject);
        }
    }

    [Serializable]
    public class HpEvent
    {
        public Comparison hpComparison;
        public float hpPercentage = .5f;
        [AssetsOnly]
        public GameEvent gameEvent;
    }

    public enum Comparison { LessThan, GreaterThank, EqualTo }
}