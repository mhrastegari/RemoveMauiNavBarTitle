# RemoveMauiNavBarTitle

This project demonstrates how to hide the .NET MAUI Shell TabBar labels when no titles are set, on Android.

The custom [AndroidShellRenderer](https://github.com/mhrastegari/RemoveMauiNavBarTitle/blob/main/src/Platforms/Android/Renderers/AndroidShellRenderer.cs) conditionally hides labels only if no tab has a title.

# Results

### Before (Labels always visible)

![Before](https://github.com/mhrastegari/RemoveMauiNavBarTitle/blob/main/before.png)

### After (Labels hidden if no titles)

![After](https://github.com/mhrastegari/RemoveMauiNavBarTitle/blob/main/after.png)
