using SkiaSharp;

namespace AdoptAMonsterSite.Services;

/// <summary>
/// Service for resizing images while maintaining aspect ratio
/// </summary>
public class ImageResizerService
{
    /// <summary>
    /// Resizes an image to a specified width while maintaining aspect ratio
    /// </summary>
    /// <param name="inputStream">Input image stream</param>
    /// <param name="outputStream">Output stream for the resized image</param>
    /// <param name="targetWidth">Target width in pixels</param>
    /// <param name="quality">JPEG quality (0-100), default is 85</param>
    public void ResizeImage(Stream inputStream, Stream outputStream, int targetWidth, int quality = 85)
    {
        using var inputBitmap = SKBitmap.Decode(inputStream);
        
        if (inputBitmap == null)
        {
            throw new InvalidOperationException("Failed to decode image");
        }

        // Calculate the new height maintaining aspect ratio
        var aspectRatio = (double)inputBitmap.Height / inputBitmap.Width;
        var targetHeight = (int)(targetWidth * aspectRatio);

        // Check if the image has an alpha channel (transparency)
        bool hasAlpha = inputBitmap.AlphaType != SKAlphaType.Opaque;

        // Create image info with proper alpha type to preserve transparency
        var imageInfo = new SKImageInfo(
            targetWidth, 
            targetHeight,
            inputBitmap.ColorType,
            hasAlpha ? SKAlphaType.Premul : SKAlphaType.Opaque
        );

        // Create the resized bitmap with proper alpha support
        // Use SKSamplingOptions instead of the obsolete SKFilterQuality overload
        var sampling = new SKSamplingOptions(SKFilterMode.Linear, SKMipmapMode.None);
        using var resizedBitmap = inputBitmap.Resize(imageInfo, sampling);
        
        if (resizedBitmap == null)
        {
            throw new InvalidOperationException("Failed to resize image");
        }

        // Encode and save the image
        using var image = SKImage.FromBitmap(resizedBitmap);
        
        // Use PNG format if the image has transparency, otherwise use JPEG
        if (hasAlpha)
        {
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            data.SaveTo(outputStream);
        }
        else
        {
            using var data = image.Encode(SKEncodedImageFormat.Jpeg, quality);
            data.SaveTo(outputStream);
        }
    }
}
