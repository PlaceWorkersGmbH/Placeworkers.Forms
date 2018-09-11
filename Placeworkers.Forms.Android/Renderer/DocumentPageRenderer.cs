using System;
using System.ComponentModel;
using Android.Content;
using Android.Views;
using Android.Widget;
using Com.Github.Barteksc.Pdfviewer.Util;
using Java.IO;
using Placeworkers.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DocumentPage), typeof(DocumentPageRenderer))]
namespace Placeworkers.Forms
{
    public class DocumentPageRenderer : VisualElementRenderer<DocumentPage>
    {
        Android.Views.View _view;

        public DocumentPageRenderer(Context context) : base(context) => AutoPackage = false;

        protected override void Dispose(bool disposing)
        {
            if (disposing && _view != null)
            {
                _view.Dispose();
                _view = null;
            }
            base.Dispose(disposing);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            if (_view != null)
            {
                _view.Measure(MeasureSpecFactory.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly), MeasureSpecFactory.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly));
                _view.Layout(0, 0, r - l, b - t);
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DocumentPage> e)
        {
            base.OnElementChanged(e);
            UpdateDataSource(e.NewElement.FilePath);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == DocumentPage.FilePathProperty.PropertyName)
                UpdateDataSource(Element.FilePath);
        }

        void UpdateDataSource(string path)
        {
            if (_view != null)
            {
                RemoveView(_view);
                _view.Dispose();
            }
            if (path != null)
            {
                var mimeType = MimeTypeMapper.GetMimeTypeByFileName(path);
                if (mimeType.Contains("pdf"))
                {
                    var pdfView = new Com.Github.Barteksc.Pdfviewer.PDFView(Context, null);
                    var uri = Android.Net.Uri.FromFile(new File(path));
                    pdfView.FromUri(uri).PageFitPolicy(FitPolicy.Width).Load();
                    _view = pdfView;
                    AddView(pdfView);
                }
                else
                {
                    _view = new TextView(Context)
                    {
                        Text = Resources.GetString(GetResourceId("DocumentNotSupported", "string", Context.PackageName))
                    };
                    AddView(_view);
                }
            }
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            _view.Measure(widthMeasureSpec, heightMeasureSpec);
            SetMeasuredDimension(_view.MeasuredWidth, _view.MeasuredHeight);
        }

        public int GetResourceId(string pVariableName, string pResourcename, string pPackageName)
        {
            try { return Resources.GetIdentifier(pVariableName, pResourcename, pPackageName); }
            catch (Exception) { return -1; }
        }

    }
}