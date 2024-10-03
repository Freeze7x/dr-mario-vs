using Godot;
using System;
using System.Runtime.Intrinsics;

public partial class Player : Node2D
{
	[Export]
	private Node2D dim, playfield;
	[Export]
	private PackedScene cell;
	// 8 by 16
	public Cell[,] Playfield = new Cell[8, 16];

	public override void _Ready()
	{
		SetSize(8, 16);
		SetCell(1, 1, CellColor.Yellow, CellRotation.Right);
	}

	public override void _Process(double delta)
	{
	}

	public void Tick() {
		
	}

	public void SetSize(int rows, int columns)
	{
		Playfield = new Cell[rows, columns];
		dim.Scale = new(rows * 32f, columns * 32f);
		dim.Position = new(dim.Scale.X / -2, dim.Scale.Y / -2);
		playfield.Position = dim.Scale/-2f;
	}

	public void SetCell(int X, int Y, CellColor cellColor, CellRotation cellRotation)
	{
		if (Playfield[X, Y] == null)
		{
			Cell newcell = cell.Instantiate<Cell>();

			playfield.AddChild(newcell);
			Playfield[X, Y] = newcell;
			newcell.Position = new(X * 32f, Y * 32f);
		}
		else
		{
			Playfield[X, Y].SetState(cellColor, cellRotation);
		}
	}

	public void DeleteCell(int X, int Y)
	{
		Playfield[X, Y]?.QueueFree();
		Playfield[X, Y] = null;
	}
}
