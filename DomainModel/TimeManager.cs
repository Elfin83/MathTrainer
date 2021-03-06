﻿using System;
using System.Threading;
using System.Diagnostics.Contracts;

namespace MathTrainer
{
    public class TimeManager
    {
        public static Timer _timer;        
        private static decimal _tick;
        private static decimal _timeLimit;
        
        public decimal TimeLimit
        {
            set
            {
                _timeLimit = value;
            }
        }  

        public static void StartTimer(decimal timeLimit)
        {
            Contract.Requires<ArgumentOutOfRangeException>(timeLimit > 0, "timeLimit");            
            _timeLimit = timeLimit;            
            _tick = 0;
            _timer = new Timer(TimerTick, null, 1000, 1000);           
        }
        
        public static void StopTimer()
        {
            //Contract.Requires<ArgumentNullException>(_timer != null,"_timer");
            if (_timer == null) { return; }
            else _timer.Dispose();
        }

        private static void TimerTick(object data)
        {
            if (_tick == _timeLimit)
            {
                //Notify presenter when time is up
                if (TimeIsUp != null)
                {
                    TimeIsUp(_timer, EventArgs.Empty);
                }         
            }
            else
            {                
                _tick++;
                //Notify presenter when next tick
                if (Tick != null)
                {
                    Tick(_timer, EventArgs.Empty);
                }
            }
        }

        public static event EventHandler Tick;
        public static event EventHandler TimeIsUp;
    }
}
