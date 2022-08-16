namespace TopGrade;

public class Buffer
{
    private readonly int[] _indexes;
    private readonly int _sortFactor;
    private int _previousLeftBorder = 0;
    private int _leftBorder = 0;
    private int _maxValue = 0;
        
    public Buffer(int sortFactor, int maxValue)
    {
        _sortFactor = sortFactor;
        _maxValue = maxValue;
        _indexes = new int[sortFactor + 1];
    }

    public void AddValue(int value)
    {
        this[value]++;
    }

    public void TryMoveBorder(int value = -1)
    {
        if (value == -1)
        {
            MoveBorder(_maxValue);
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
        }
    }

    private int this[int i]
    {
        get => _indexes[GetIndex(i)];
        set => _indexes[GetIndex(i)] = value;
    }

    private int GetIndex(int index)
    {
        return index;
    }
}