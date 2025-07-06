using System.Web;

namespace Shoper.WebApp.Helpers
{
    public static class ImageHelper
    {
        private const string IMAGE_SERVICE_URL = "https://images.weserv.nl/";
        public const string DEFAULT_IMAGE = "/images/default-product.jpg";
        
        public static string GetOptimizedImageUrl(string originalUrl, int width = 450, int height = 600, int quality = 85, string format = "webp")
        {
            if (string.IsNullOrEmpty(originalUrl))
                return DEFAULT_IMAGE;
            
            var encodedUrl = HttpUtility.UrlEncode(originalUrl);
            
            var optimizedUrl = $"{IMAGE_SERVICE_URL}?url={encodedUrl}&w={width}&h={height}&fit=cover&q={quality}&output={format}";
            
            return optimizedUrl;
        }
        
        public static string GetProductImageUrl(string originalUrl, int width = 450, int height = 600)
        {
            return GetOptimizedImageUrl(originalUrl, width, height, 90, "webp");
        }
        
        public static string GetThumbnailUrl(string originalUrl, int size = 150)
        {
            return GetOptimizedImageUrl(originalUrl, size, size, 80, "webp");
        }
        
        public static string GetHeroImageUrl(string originalUrl, int width = 1200, int height = 600)
        {
            return GetOptimizedImageUrl(originalUrl, width, height, 95, "webp");
        }
        
        public static string GetCartImageUrl(string originalUrl, int size = 80)
        {
            return GetOptimizedImageUrl(originalUrl, size, size, 85, "webp");
        }
        
        public static string GetCategoryImageUrl(string originalUrl, int width = 300, int height = 200)
        {
            return GetOptimizedImageUrl(originalUrl, width, height, 88, "webp");
        }
        
        // Responsive image URLs for different screen sizes
        public static class Responsive
        {
            public static string GetMobileUrl(string originalUrl) => GetOptimizedImageUrl(originalUrl, 300, 400, 85);
            public static string GetTabletUrl(string originalUrl) => GetOptimizedImageUrl(originalUrl, 600, 800, 90);
            public static string GetDesktopUrl(string originalUrl) => GetOptimizedImageUrl(originalUrl, 900, 1200, 95);
        }
        
        // Lazy loading için srcset oluştur
        public static string GetSrcSet(string originalUrl, int[]? sizes = null)
        {
            if (sizes == null)
                sizes = new[] { 300, 600, 900, 1200 };
                
            var srcSet = string.Join(", ", sizes.Select(size => 
                $"{GetOptimizedImageUrl(originalUrl, size, size * 4/3, 85)} {size}w"));
                
            return srcSet;
        }
    }
} 