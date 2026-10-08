namespace CrapFixer.Services;

// sorts ListView rows when a column header is clicked
internal sealed class ListViewColumnSorter : System.Collections.IComparer
{
    public int SortColumn;
    public SortOrder Order = SortOrder.Ascending;
    public Func<ListViewItem, int, IComparable>? KeySelector;

    // compares two rows using the selected column
    public int Compare(object? x, object? y)
    {
        if (KeySelector is null || x is not ListViewItem a || y is not ListViewItem b) return 0;

        var result = KeySelector(a, SortColumn).CompareTo(KeySelector(b, SortColumn));
        return Order == SortOrder.Descending ? -result : result;
    }

    // same column flips direction, another starts ascending
    public void ToggleSort(int column)
    {
        if (SortColumn == column)
            Order = Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
        else
        {
            SortColumn = column;
            Order = SortOrder.Ascending;
        }
    }
}
