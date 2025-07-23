using UIKit;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace RemoveMauiNavBarTitle.Platforms.iOS.Renderers;

public class iOSShellRenderer : ShellRenderer
{
    protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
    {
        return new iOSTabBarAppearanceTracker(this);
    }
}

public class iOSTabBarAppearanceTracker : ShellTabBarAppearanceTracker
{
    private readonly IShellContext _shellContext;

    public iOSTabBarAppearanceTracker(IShellContext shellContext)
    {
        _shellContext = shellContext;
    }

    public override void UpdateLayout(UITabBarController controller)
    {
        base.UpdateLayout(controller);

        var shellItem = _shellContext.Shell.CurrentItem;
        var hasAnyTitle = shellItem.Items
            .OfType<ShellSection>()
            .Any(section =>
                !string.IsNullOrWhiteSpace(section.Title) ||
                section.Items.Any(content => !string.IsNullOrWhiteSpace(content.Title))
            );

        if (hasAnyTitle) return;
        if (controller.TabBar.Items is null) return;

        foreach (var item in controller.TabBar.Items)
        {
            item.Title = string.Empty;
            item.ImageInsets = new UIEdgeInsets(6, 0, -6, 0);
        }
    }
}
