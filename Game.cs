using Microsoft.AspNetCore.Components;

namespace Minesweeper.Components.Pages;


public class MinesAndFlags() :Home
{
    public readonly HashSet<string?> Arr = new();
    public List<string> ForFlags = new();
    public bool doesGameEnd;
    readonly Random _rng = new ();

   

    public IEnumerable<string> GetMines(int size,int minesAndFlags,int count)
    {
        while (Arr.Count < minesAndFlags+count)
        {
            var randomNumber = $"{_rng.Next(0, size)},{_rng.Next(0, size)}";
            if (Arr.Add(randomNumber))
            {
                yield return randomNumber;
            }
            
        }

        for (int i = 0; i < minesAndFlags; i++)
        {
            Arr.Remove(Arr.Last());
        }
    }

    public RenderFragment EndGame => builder =>
    {
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", "game-end");
        builder.OpenElement(1, "div");
        builder.AddContent(2, Game.EndGameText);
        builder.CloseElement();
        builder.OpenElement(1, "div");
        builder.AddAttribute(1, "class", "middle-div");
        builder.OpenElement(2, "div");
        builder.CloseElement();
        builder.OpenElement(2, "div");
        builder.AddContent(3,$"{TimeSpan.FromSeconds(Play.timer.Seconds).ToString(@"mm\:ss")}");
        builder.CloseElement();
        builder.CloseElement();
        
        builder.CloseElement();
    };
}

public class Time
{
    public int Seconds { get; private set; }
    public Action? OnTick { get; set; } 
        
    private int _endTime = 99 * 60;
    private bool _running;

    public async Task StartTimer()
    {
        if (_running) return;
        _running = true;

        using var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(1));
        while (Seconds < _endTime && await periodicTimer.WaitForNextTickAsync())
        {
            if (Play.Game.Tools.doesGameEnd)
            {
                break;
            }
            Seconds++;
            OnTick?.Invoke();
        }
        
        _running = false;
    }
   
}
