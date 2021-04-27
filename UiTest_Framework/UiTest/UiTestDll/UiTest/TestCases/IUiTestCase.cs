using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using UnityEngine;

namespace Assets.UiTest.Runner
{
    public interface IUiTestCase
    {
        IEnumerator Run(IUiTestContext context);
        void Stop();
    }
}