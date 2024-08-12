using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Logging;
using Avalonia.Media;
using SkiaSharp;


using Dbg = System.Diagnostics.Debug;

namespace ArcsUI.Controls;

public class MapWidget : Control
{
    
    public static readonly DirectProperty<MapWidget, int> NumRingsProperty =
        AvaloniaProperty.RegisterDirect<MapWidget, int>(nameof(NumRings),
            o => o.NumRings,
            (o, v) => o.NumRings = v);
    private int _numRings = 3;
    public int NumRings
    {
        get { return _numRings;  }
        set
        {
            if (SetAndRaise(NumRingsProperty, ref _numRings, value))
            {
                InvalidateVisual();
            }
        }
    }

    public static readonly StyledProperty<IBrush?> RingDrawProperty =
        AvaloniaProperty.Register<MapWidget, IBrush?>(nameof(RingDraw));

    public static readonly StyledProperty<IBrush?>? RegionFillProperty = 
        AvaloniaProperty.Register<MapWidget, IBrush?>(nameof(RegionFill));

    public IBrush? RingDraw
    {
        get { return GetValue(RingDrawProperty); }
        set { SetValue(RingDrawProperty, value); }
    }
    
    public IBrush? RegionFill
    {
        get { return GetValue(RegionFillProperty); }
        set { SetValue(RegionFillProperty, value); }
    }

    public sealed override void Render(DrawingContext context)
    {
        Logger.TryGet(LogEventLevel.Fatal, LogArea.Control)?.Log(this, "Avalonia Infrastructure");
        System.Diagnostics.Debug.WriteLine("System Diagnostics Debug");
        Dbg.WriteLine("System Diagnostics Debug (short)");
        
        System.Diagnostics.Debug.WriteLine($"(diag) Version is {SkiaSharpVersion.Native}");
        System.Console.WriteLine($"(console) Version is {SkiaSharpVersion.Native}");
        
        var renderSize = Bounds.Size;

        Rect HubRect = (Bounds.Width >= Bounds.Height)
            ? new Rect((Bounds.Width - Bounds.Height) / 2.0, 0.0, Bounds.Height, Bounds.Height)
            : new Rect(0.0, (Bounds.Height - Bounds.Width) / 2.0,  Bounds.Width, Bounds.Width);

        var ringStroke = new Pen(RingDraw, 2.0);
        context.DrawEllipse( RegionFill, null, HubRect );


        if (_numRings > 0)
        {
            double ringSz = (HubRect.Width / 2.0) / _numRings;
            System.Diagnostics.Debug.WriteLine($"NumRings is {NumRings} ringSz is {ringSz}");
            for (int i = 0; i < _numRings; i++)
            {
                context.DrawEllipse(null, ringStroke, HubRect.Center, ringSz * (i + 1), ringSz * (i + 1));
            }
        }


        base.Render(context);
    }
}