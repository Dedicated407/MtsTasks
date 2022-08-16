namespace TopGrade;

public class Sorter
{
    private readonly int[] _indexes;
    private readonly int _sortFactor;
    private readonly int _maxValue;
    private int _previousLeftBorder;
    private int _leftBorder;
        
    public Sorter(int sortFactor, int maxValue)
    {
        _sortFactor = sortFactor;
        _maxValue = maxValue;
        var size = Math.Min(sortFactor * 2, maxValue);
        _indexes = new int[size + 1];
    }

    public void AddValue(int value)
    {
        this[value]++;
    }

    public void TryMoveBorder(int value = -1)
    {
        if (value == -1)
        {
            MoveBorder(_maxValue + 1);
        }
        
        var border = value - (_sortFactor + 1);
            
        if (border > 0)
        { 
            MoveBorder(border);
        }
    }

    private void MoveBorder(int border)
    {
        _previousLeftBorder = _leftBorder;
        _leftBorder = border;
    }

    public IEnumerable<int> GetCurrentSequence()
    {
        for (int i = _previousLeftBorder; i < _leftBorder; i++)
        {
            for (int j = 0; j < this[i]; j++)
            {
                yield return i;   
            }

            this[i] = 0;
        }
    }

    private int this[int i]
    {
        get => _indexes[GetIndex(i)];
        set => _indexes[GetIndex(i)] = value;
    }

    private int GetIndex(int index)
    {
        return index % _indexes.Length;
    }
}