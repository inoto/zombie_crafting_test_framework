using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.TestSteps.Trees;
using UnityEngine;

namespace Assets.UiTest.TestSteps
{
    public class Steps
    {

        public Steps(IUiTestContext context)
        {
            UiTestStepBase.SetContext(context);
        }
    
        public IUiTestStepBase ExampleStep()
        {
            return new ExampleStep();
        }

        public IUiTestStepBase WaitGameLoadedStep()
        {
            return new WaitGameLoadedStep();
        }
        
        public IUiTestStepBase InventoryOpenStep()
        {
            return new Inventory_OpenStep();
        }
        
        public IUiTestStepBase InventoryCloseStep()
        {
            return new Inventory_CloseStep();
        }
        
        public IUiTestStepBase PlayerMoveSawmillStep()
        {
            return new Player_MoveToSawmillStep();
        }

        public IUiTestStepBase WorkbenchSawmill_OpenStep()
        {
            return new WorkbenchSawmill_OpenStep();
        }
        
        public IUiTestStepBase WorkbenchSawmill_CloseStep()
        {
            return new WorkbenchSawmill_CloseStep();
        }
        
        public IUiTestStepBase WorkbenchSawmill_GetWoodAndPutToRowStep()
        {
            return new WorkbenchSawmill_GetWoodAndPutToRowStep();
        }

    }
}
