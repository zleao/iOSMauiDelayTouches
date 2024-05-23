using CommunityToolkit.Maui.Views;

namespace iOSDelayTouches.Views;

public partial class ScrollViewlPage : ContentPage
{
	public ScrollViewlPage()
	{
		InitializeComponent();
	}

	private void ClearClicked(object sender, EventArgs e)
	{
		Drawing.Clear();
        GeneratedImage.Source = null;
    }

	private async void SaveClicked(object sender, EventArgs e)
	{
		var drawingLines = Drawing.Lines.ToList();

		if (!drawingLines.Any())
		{
			return;
		}

		var points = drawingLines.SelectMany(x => x.Points).ToList();

		var stream = await DrawingView.GetImageStream(
			drawingLines,
			new Size(points.Max(x => x.X) - points.Min(x => x.X), points.Max(x => x.Y) - points.Min(x => x.Y)),
			Colors.Gray);

		GeneratedImage.Source = ImageSource.FromStream(() => stream);
	}
}
