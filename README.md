# Placeworkers.Forms
-

is a custom controls library for Xamarin.Form with support for iOS and Android.

#### Included Controls:

- **DateTimePicker:** 
	- *iOS:* Implemented like a standard DatePicker but in DateTime mode.
	- *Android:* Implemented to show a TimePickerDialog after a DatePickerDialog.
- **NavigationButton:** Button with left text alignment and a possible right aligned image
- **NavicationCell:** Standard TextCell with DisclosureIndicator on right side (AccessoryView). Uses Right DrawerArrowDrawable as right arrow on Android.
- **ExtendedListView:** Standard ListView with option to disable scrolling.

#### Usage:

Add Placeworkers.Forms reference to your projects.
	
##### XAML:

add assembly namespace: 
	
	xmlns:pw="clr-namespace:Placeworkers.Forms;assembly=Placeworkers.Forms"

use control:

	<pw:NavigationButton Text="Navigation" Image="ArrowRight" />

#####Code-Behind:
	
	var navButton = new NavigationButton(){ ... }  	