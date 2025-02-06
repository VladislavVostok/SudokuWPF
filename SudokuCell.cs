using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuWPF
{
	public class SudokuCell
	{
		public int Row { get; set; }
		public int Col { get; set; }
		public	string Value {  get; set; }
		public	bool IsFixed { get; set; }

	}
}
