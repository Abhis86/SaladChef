using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class StaticCoroutine : AutoInstantiateSingleton<StaticCoroutine>
    {
        protected override void Awake()
        {
            _PersistentOnSceneChange = true;
            base.Awake();
        }
        public static void Start(IEnumerator coroutine)
        {
            pInstance.StartCoroutine(coroutine);
        }
    }
}
