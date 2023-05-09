using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public enum MUMMY_TYPES
    {
        Spitter_Mummy,//0
        Melee_Mummy,//1

    }
    public interface IAttackable
    {
        public void Attack();
    }

}
