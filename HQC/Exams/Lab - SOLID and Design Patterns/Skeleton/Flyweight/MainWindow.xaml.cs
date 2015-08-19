namespace ReaperInvasion
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using ReaperInvasion.GameObjects;
    using ReaperInvasion.UI;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            var canvas = this.FindName("canvas") as Canvas;
            int width = (int) canvas.Width;
            int height = (int) canvas.Height;

            var assetLoader = AssetLoader.Instance;
            var renderer = new Renderer(canvas, assetLoader);

            var randomGenerator = new Random();
            for (int i = 0; i < 10000; i++)
            {
                int x = randomGenerator.Next(0, width);
                int y = randomGenerator.Next(0, height);

                renderer.Render(new Reaper(x, y));
            }  
        }
    }
}
