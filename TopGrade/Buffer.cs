namespace TopGrade;

public class Buffer
{
    private readonly int[] _indexes;
    private readonly int _sortFactor;
    private int _previousLeftBorder = 0;
    private int _leftBorder = 0;
        
    public Buffer(int sortFactor, int maxValue)
    {
        _indexes = new int[maxValue + 1];
        _sortFactor = sortFactor;
    }

    public void AddValue(int value)
    {
        var border = value - (_sortFactor + 1);
            
        if (border > 0)
        { 
            MoveBorder(border);
        }
            
        this[value]++;
    }

    private void MoveBorder(int border)
    {
        _previousLeftBorder = _leftBorder;
        _leftBorder = border;
    }

    public void FlushBuffer()
    {
        MoveBorder(_indexes.Length);
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