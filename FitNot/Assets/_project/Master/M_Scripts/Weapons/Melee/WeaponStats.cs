using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    [CreateAssetMenu(fileName = "New weapon", menuName = "Weapons/create weapon stats")]
    public class WeaponStats : ScriptableObject
    {
        public int damage;
        public int durability;
        public float attackRange;
        public int projectileCount;

    }
}
