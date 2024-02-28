using System;
using System.Collections.Generic;

class Cell
{
    public bool IsAlive { get; set; }
    public int X { get; }
    public int Y { get; }
    private int survivalCountdown;

    public Cell(int x, int y, bool isAlive)
    {
        X = x;
        Y = y;
        IsAlive = isAlive;
        survivalCountdown = 3; // Initialize countdown for survival
    }

    public void UpdateState(int neighbors)
    {
        if (neighbors < 2 || neighbors > 3)
        {
            // Die due to overpopulation or underpopulation
            IsAlive = false;
            survivalCountdown = 3;
        }
        else if (neighbors == 3)
        {
            // Propagate new cell if 3 neighbors exist
            IsAlive = true;
            survivalCountdown = 3;
        }
        else if (neighbors == 0)
        {
            // Die due to isolation
            survivalCountdown--;
            if (survivalCountdown <= 0)
            {
                IsAlive = false;
            }
        }
    }
}

class GameOfLife
{
    private const int GridSize = 100;
    private const int MaxEntities = 5;

    private Cell[,] grid;

    public GameOfLife()
    {
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        grid = new Cell[GridSize, GridSize];
        // Initialize all cells as dead
        for (int x = 0; x < GridSize; x++)
        {
            for (int y = 0; y < GridSize; y++)
            {
                grid[x, y] = new Cell(x, y, false);
            }
        }
        // Randomly populate cells with entities
        Random random = new Random();
        for (int i = 0; i < GridSize * GridSize / 10; i++)
        {
            int x = random.Next(0, GridSize);
            int y = random.Next(0, GridSize);
            grid[x, y].IsAlive = true;
        }
    }

    public void RunSimulation()
    {
        for (int cycle = 0; cycle < 10; cycle++) // Run for 10 cycles as an example
        {
            UpdateGrid();
            DisplayGrid();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private void UpdateGrid()
    {
        Cell[,] newGrid = new Cell[GridSize, GridSize];
        for (int x = 0; x < GridSize; x++)
        {
            for (int y = 0; y < GridSize; y++)
            {
                int neighborCount = CountNeighbors(x, y);
                grid[x, y].UpdateState(neighborCount);
                newGrid[x, y] = new Cell(x, y, grid[x, y].IsAlive);
            }
        }
        grid = newGrid;
    }

    private int CountNeighbors(int x, int y)
    {
        int count = 0;
        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i >= 0 && i < GridSize && j >= 0 && j < GridSize && !(i == x && j == y))
                {
                    if (grid[i, j].IsAlive)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    private void DisplayGrid()
    {
        for (int y = 0; y < GridSize; y++)
        {
            for (int x = 0; x < GridSize; x++)
            {
                Console.Write(grid[x, y].IsAlive ? "X" : ".");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        GameOfLife game = new GameOfLife();
        game.RunSimulation();
    }
}