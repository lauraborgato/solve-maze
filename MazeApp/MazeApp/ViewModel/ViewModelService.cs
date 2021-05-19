﻿using System;
using System.IO;
using System.Linq;
using Maze.Interface;
using Microsoft.Win32;

namespace MazeApp.ViewModel
{
    class ViewModelService : IViewModelService
    {
        private readonly ICalculate SolveMazeService;
        private readonly ILoadMaze LoadMazeSerivce;
        public int MAXCOL { get; set; }
        public int MAXROW { get; set; }

        public ViewModelService(ICalculate solveMazeService, ILoadMaze loadMazeService)
        {
            SolveMazeService = solveMazeService;
            LoadMazeSerivce = loadMazeService;
        }

        public void LoadMazeFromFile(OpenFileDialog file = null)
        {
            if (file != null)
            {
                var streamReader = new StreamReader(file.FileName);
                LoadMazeSerivce.CrateMazeFromFile(streamReader);
            }
            else LoadMazeSerivce.CreateMaze();
            MAXCOL = LoadMazeSerivce.MAXCOL;
            MAXROW = LoadMazeSerivce.MAXROW;
        }

        public int[,] SoveMaze()
        {
            return SolveMazeService.Solve();
        }
    }
}
