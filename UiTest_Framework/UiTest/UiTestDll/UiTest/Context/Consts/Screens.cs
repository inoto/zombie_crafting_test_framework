using System;
using System.Linq.Expressions;
using Assets.UiTest.Results;
using Assets.UiTest.TestSteps;

namespace Assets.UiTest.Context.Consts
{
    public static class Screens
    {
        public static readonly Main Main = new Main();
        public static readonly Inventory Inventory = new Inventory(); 
        public static readonly Start Start = new Start(); 
    }
}