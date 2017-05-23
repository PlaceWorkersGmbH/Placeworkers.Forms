namespace Placeworkers.Forms
{
    public class Initializer
    {
		public static void Init()
		{
			// Have to instantiate one of the renderers to stop the Xamarin linker removing them
			// from release builds
			#pragma warning disable CS0219 // Variable is assigned but its value is never used
			DateTimePickerRenderer r = new DateTimePickerRenderer();
			#pragma warning restore CS0219
		}
    }
}
