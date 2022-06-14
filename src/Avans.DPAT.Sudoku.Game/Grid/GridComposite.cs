using System.Drawing;
using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Game.Grid;

public class GridComposite : IGridComponent
{
    private readonly IList<IGridComponent> _children;

    public GridComposite(IList<IGridComponent> children)
    {
        _children = children;
    }

    public IEnumerable<IGridComponent> ToList()
    {
        return _children.SelectMany(component => component.ToList());
    }

    public bool IsValid(Point point, int number)
    {
        if (!Contains(point)) return true;

        var cells = _children.OfType<ICell>().ToList();
        if (!cells.Any()) return _children.All(component => component.IsValid(point, number));

        var numbers = new List<int>();
        foreach (var cell in cells)
        {
            if (cell.Position == point)
            {
                numbers.Add(number);
            }
            else if (cell.Value.HasValue)
            {
                numbers.Add(cell.Value.Value);
            }
        }

        return numbers.Count == numbers.Distinct().Count();
    }

    public bool Contains(Point point)
    {
        return _children.Any(component => component.Contains(point));
    }
}
