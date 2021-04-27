using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.UiTest.Context;
using UnityEngine;

namespace Assets.UiTest.Runner
{
    public abstract class UiSimpleTestCase : IUiTestCase
    {

        public IEnumerator Run(IUiTestContext context)
        {
            yield return OnRun(context);
        }

        protected abstract IEnumerator OnRun(IUiTestContext context);

        public void Stop()
        {
        }
    }
}