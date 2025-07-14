using Android.Content;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace RemoveMauiNavBarTitle.Platforms.Android.Renderers;

public class AndroidShellRenderer : ShellRenderer
{
    public AndroidShellRenderer(Context context) : base(context) { }

    protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
    {
        return new AndroidBottomNavAppearanceTracker(this, shellItem);
    }
}

public class AndroidBottomNavAppearanceTracker : ShellBottomNavViewAppearanceTracker
{
    private readonly ShellItem _shellItem;

    public AndroidBottomNavAppearanceTracker(IShellContext shellContext, ShellItem shellItem) : base(shellContext, shellItem)
    {
        _shellItem = shellItem;
    }

    public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
    {
        base.SetAppearance(bottomView, appearance);

        var hasAnyTitle = _shellItem.Items
            .OfType<ShellSection>()
            .Any(section =>
                !string.IsNullOrWhiteSpace(section.Title) ||
                section.Items.Any(content => !string.IsNullOrWhiteSpace(content.Title))
            );

        if (hasAnyTitle is false)
        {
            bottomView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityUnlabeled;
        }
    }
}
