namespace CrapFixer;

// swaps the page in the white content area
internal sealed class NavigationManager
{
    private readonly Panel _container;
    private Control? _current;

    public NavigationManager(Panel container) => _container = container;

    public void SwitchView(Control view)
    {
        if (ReferenceEquals(_current, view)) return;

        _container.SuspendLayout();
        _container.Controls.Clear();
        view.Dock = DockStyle.Fill;
        _container.Controls.Add(view);
        _container.ResumeLayout();
        _current = view;
    }
}
