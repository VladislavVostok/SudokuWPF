namespace SudokuWPF
{
	public class SudokuSolver
	{
		const int SIZE_CELL = 9;
		private int[,] board = new int[SIZE_CELL, SIZE_CELL];
		private Random random = new Random();

		public int[,] Board => board;

		public void GeneratePuzzle()
		{
			ClearBoard();
			Solve();
			RemoveNumber();
		}

		private void ClearBoard()
		{
			for (int i = 0; i < SIZE_CELL; i++)
			{
				for (int j = 0; j < SIZE_CELL; j++)
				{
					board[i, j] = 0;
				}
			}
		}

		public bool Solve()
		{
			return BacktrackSolve(0, 0);
		}

		private bool BacktrackSolve(int row, int col)
		{
			if (row == 9) return true;
			if (col == 9) return BacktrackSolve(row + 1, 0);
			if (board[row, col] != 0) return BacktrackSolve(row, col + 1);

			var nubers = Enumerable.Range(1, SIZE_CELL).OrderBy(x => random.Next()).ToList();

			foreach (var num in nubers)
			{
				if (IsValid(row, col, num))
				{
					board[row, col] = num;
					if (BacktrackSolve(row, col + 1)) return true;

					board[row, col] = 0;
				}
			}
			return false;
		}

		private bool IsValid(int row, int col, int num)
		{
			for (int i = 0; i < SIZE_CELL; i++)
			{

				if (board[row, i] == num || board[i, col] == num)
				{
					return false;
				}
			}

			int boxRow = (row / 3) * 3;
			int boxCol = (col / 3) * 3;

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (board[boxRow + i, boxCol + j] == num)
						return false;
				}
			}

			return true;
		}

		private void RemoveNumber()
		{
			int difficulty = 40;

			for(int i = 0; i < difficulty; i++)
			{
				int row, col;

				do
				{
					row = random.Next(9);
					col = random.Next(9);
				} while (board[row, col] == 0);
				
				board[row, col] = 0;
			}
		}

		public bool IsSolved()
		{
			return Board.Cast<int>().All(x => x > 0);
		}
	}
}