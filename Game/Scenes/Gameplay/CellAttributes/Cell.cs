using System.Collections.Generic;
using System.Reflection.Emit;
using Godot;

public partial class Cell : AnimatedSprite2D
{
    public static Dictionary<CellColor, Color> EnumToColor = new()
    {
        { CellColor.Red, new(1, 0, 0) },
        { CellColor.Yellow, new(1, 1, 0) },
        { CellColor.Blue, new(0, 0, 1) }
    };
    public CellColor CellColor;
    public CellRotation Direction = CellRotation.Right;

    public void SetState(CellColor cellColor, CellRotation direction)
    {
        CellColor = cellColor;
        Direction = direction;

        RotationDegrees = (int)direction * 90;
        Modulate = EnumToColor[cellColor];
    }
}