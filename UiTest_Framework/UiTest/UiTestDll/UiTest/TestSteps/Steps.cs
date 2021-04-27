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

        public IUiTestStepBase InventoryOpenStep()
        {
            return new InventoryOpenStep();
        }
        
        public IUiTestStepBase InventoryCloseStep()
        {
            return new InventoryCloseStep();
        }
        
        public IUiTestStepBase InventoryMoveItemStep()
        {
            return new InventoryMoveItemStep();
        }
        
        public IUiTestStepBase InventoryGetAllItems()
        {
            return new InventoryMoveItemStep();
        }
        
        public IUiTestStepBase PlayerMoveSawmillStep()
        {
            return new PlayerMoveSawmillStep();
        }

        public IUiTestStepBase FindItemStep()
        {
            return new FindItemStep();
        }
        
        public IUiTestStepBase TreesGoToClosestTreeStep()
        {
            return new TreesGoToClosestTreeStep();
        }
		
        public IUiTestStepBase TreesHarvestTree1TimeStep()
        {
            return new TreesHarvestTree1TimeStep();
        }
		
        public IUiTestStepBase TreesFullyHarvestTreeStep()
        {
            return new TreesFullyHarvestTreeStep();
        }
		
        public IUiTestStepBase TreesHarvestWithoutAxeStep()
        {
            return new TreesHarvestWithoutAxeStep();
        }
    }
}