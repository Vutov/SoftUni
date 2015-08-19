namespace ReaperInvasion.UI
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public sealed class AssetLoader
    {
        private static readonly AssetLoader instance = new AssetLoader();
        private IDictionary<AssetType, ImageSource> imageSourcesPerAsset; 

        private AssetLoader()
        {
            this.imageSourcesPerAsset = new Dictionary<AssetType, ImageSource>();
        }

        public static AssetLoader Instance
        {
            get
            {
                return instance;
            }
        }

        public Image GetImage(AssetType type)
        {
            if (!this.imageSourcesPerAsset.ContainsKey(type))
            {
                this.imageSourcesPerAsset[type] = this.LoadImage(type);
            }

            var source = this.imageSourcesPerAsset[type];
            return new Image()
            {
                Source =  source
            };
        }

        private ImageSource LoadImage(AssetType type)
        {
            string path = string.Empty;

            switch (type)
            {
                case AssetType.Reaper:
                    path = AssetPaths.ReaperImage;
                    break;
                default: 
                    throw new ArgumentException("Unsupported asset type.");
            }

            var src = new Uri(path, UriKind.Relative);

            return BitmapFrame.Create(src);
        }
    }
}
