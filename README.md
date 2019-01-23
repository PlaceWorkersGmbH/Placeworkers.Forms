# Placeworkers.Forms
is a custom controls library for Xamarin.Form with support for iOS and Android.

## Included Controls:
- **DateTimePicker:** 
 - *iOS:* Implemented like a standard DatePicker but in DateTime mode.
 - *Android:* Implemented to show a TimePickerDialog after a DatePickerDialog.
- **NavigationButton:** Button with left text alignment and a possible right aligned image
- **NavicationCell:** Standard TextCell with DisclosureIndicator on right side (AccessoryView). Uses Right DrawerArrowDrawable as right arrow on Android.
- **ExtendedListView:** Standard ListView with option to disable scrolling.
- **Checkbox:** Checkbox image on left side and text on right side. Needs 2 images for the checkbox image to work properly.
- **DocumentPage:** Page to display documents. Uses QLPreviewController on iOS and AndroidPdfViewer (https://github.com/barteksc/AndroidPdfViewer) on Android. Hence only supports PDF on Android.

### Usage

Add Placeworkers.Forms reference to your projects.

Add

 Placeworkers.Forms.Initializer.Init();

after Xamarin.Forms init.    
 
### XAML:

add assembly namespace: 
 
 xmlns:pw="clr-namespace:Placeworkers.Forms;assembly=Placeworkers.Forms"

use control:

 <pw:NavigationButton Text="Navigation" Image="ArrowRight" />

### Code-Behind:
 
 var navButton = new NavigationButton(){ ... }   

## Included Pages
- **DocumentPage:** View documents in a single view. 
 - *iOS:* QLPreviewController is used. Hence all documents supported by this preview is supported.
 - *Android:* Currently only pdf is supported via PDFium.
 
## Included Helpers
- **GridExtension:** Add a View to a Grid with Spans in one line.
- **MimeTypeMapper:** Get a MimeType from a file name.
- **ResourceLoader:** Get string/bytes from a resource from a assembly.
- **TaskExtension:** Fire and forget task with an IExceptionHandler.
- **Wildcard:** RegEx helper to simplify searches with '*' and '?'.
  
## Included Converter
- **BoolInverter**
- **BoolNotNullConverter**
- **BoolNullConverter**
- **StringIsNotNullOrWhiteSpaceConverter**