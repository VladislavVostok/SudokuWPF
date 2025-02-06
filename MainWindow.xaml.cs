using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SudokuWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private SudokuSolver solver = new SudokuSolver(); // Создание экземпляра решателя судоку
	public ObservableCollection<SudokuCell> Cells { get; set; } // Коллекция ячеек судоку, привязанная к UI
	public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

	private void NewGame()
	{
		solver.GeneratePuzzle(); // Генерация новой головоломки
		Cells = new ObservableCollection<SudokuCell>( // Создание списка ячеек
			Enumerable.Range(0, 81).Select(i => new SudokuCell
			{
				Row = i / 9, // Определение номера строки (0–8)
				Col = i % 9, // Определение номера столбца (0–8)
				Value = solver.Board[i / 9, i % 9] == 0 ? "" : solver.Board[i / 9, i % 9].ToString(), // Установка значения: пустая строка, если 0
				IsFixed = solver.Board[i / 9, i % 9] != 0 // Фиксированные ячейки (изначально заданные числа)
			}));
		SudokuCells.ItemsSource = Cells; // Привязка данных к UI (ItemsControl)
	}

	private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = !char.IsDigit(e.Text[0]) || e.Text[0] == '0';
    }

	private void NewGame_Click(object sender, RoutedEventArgs e)
	{
		NewGame(); // Создание новой игры при нажатии кнопки
	}	
    
    private void CheckSolution_Click(object sender, RoutedEventArgs e)
	{

	}    
    
    private void Solve_Click(object sender, RoutedEventArgs e)
	{

	}
}