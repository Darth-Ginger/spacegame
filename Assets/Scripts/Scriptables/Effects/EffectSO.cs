using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityRandom = UnityEngine.Random;
using NaughtyAttributes;
using CustomInspector;
using TigerForge;

namespace Spacegame.Gameplay
{
	// [CreateAssetMenu(menuName = "Spacegame/Effects/", fileName = "Effects")]
	public abstract class EffectSO : ScriptableObject
	{

        // Attributes to be set in the inspector
		public string 		Name 	{ get => name; set => _ = name; }
        public EffectTiming Timing  { get; set; } = EffectTiming.Immediate;
        public EffectType   Type 	{ get; set; } 	 = EffectType.Damage;

        // Attributes used for events
        protected GameObject source;
		protected GameObject target;

		public virtual void Apply()
		{}
		public virtual void Remove(GameObject target, GameObject source)
		{}	
	}
}