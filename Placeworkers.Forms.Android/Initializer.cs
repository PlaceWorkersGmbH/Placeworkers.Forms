namespace Placeworkers.Forms
{
    public static class Initializer
    {
		public static void Init()
		{
			// Have to instantiate one of the renderers to stop the Xamarin linker removing them
			// from release builds
			#pragma warning disable CS0219 // Variable is assigned but its value is never used
            NavigationCellRenderer r = new NavigationCellRenderer();
			#pragma warning restore CS0219
		}
    }
}
