using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;

public class StandingCommand : Command
{
    private float _standingTime;

    private Timer _timer;

    public StandingCommand(float standingTime)
    {
        _standingTime = standingTime;
    }

    public override void Execute()
    {
        _timer = new Timer(_standingTime * 1000);
        _timer.Elapsed += OnTimeElapsed;
        _timer.AutoReset = false;
        _timer.Enabled = true;
        
    }

    private void OnTimeElapsed(object sender, ElapsedEventArgs e)
    {
        IsFinished = true;
    }
}
