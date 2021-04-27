using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Results;
using UnityEngine;

namespace Assets.UiTest.TestCommands
{
    public class PlayerMoveCommand : IUiTestCommand<PlayerMoveResult>
    {
        private IUiTestContext _context;
        private Vector3 _endPosition;
        private PlayerMoveResult _result;

        public PlayerMoveCommand(IUiTestContext context, Vector3 endPosition)
        {
            _context = context;
            _endPosition = endPosition;
        }

        private float _checkMoveDuration = 1f;
        public IEnumerator Run()
        {
            var joystickPosition = new Vector2(300, 300);
            var speed = 50f;
            _context.TestTouchInput.SwipeStart(joystickPosition, joystickPosition, new Vector2(0f, 0f));

            var distanceToEndpoint = (_endPosition - _context.GetPlayerPosition()).magnitude;
                while (distanceToEndpoint > 0.5f)
                {
                    var startPosition = _context.GetPlayerPosition();

                    var direction = (_endPosition - startPosition).normalized;
                    var directionDpad = Quaternion.Euler(0, -45, 0) * direction;
                    var directionDpad2D = new Vector2(directionDpad.x, directionDpad.z);

                    var swipe = directionDpad2D * speed;
                    var end = joystickPosition + swipe;
                    _context.TestTouchInput.Swipe(joystickPosition, end, directionDpad2D);

                    yield return _context.WaitEndFrame;

                    distanceToEndpoint = (_endPosition - _context.GetPlayerPosition()).magnitude;
                    _checkMoveDuration -= Time.deltaTime;
                }
            
            _context.TestTouchInput.SwipeEnd(new Vector2(163.8f, 148.7f), new Vector2(163.8f, 125.3f), new Vector2(0.0f, 0.0f));
        }
        

        public PlayerMoveResult GetResult()
        {
            var playerPosition = _context.GetPlayerPosition();
            var endPosition = _endPosition;
            if (_context.Vector3Equal(playerPosition,endPosition, 1f))
            {
                _result = new PlayerMoveResult(false);
                
                return  _result;
            }
            _result = new PlayerMoveResult(true);
            return _result;
        }
        
        
    }
}