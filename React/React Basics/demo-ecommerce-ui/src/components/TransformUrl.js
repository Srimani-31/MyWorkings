// Function to transform a local file path into a URL path
export function transformImagePath(localPath) {
    // Replace backslashes with forward slashes
    const forwardSlashesPath = localPath.replace(/\\/g, '/');
    // Find the 'public' directory and remove everything before it
    const startIndex = forwardSlashesPath.indexOf('/assets/');
    if (startIndex !== -1) {
      const relativePath = forwardSlashesPath.substring(startIndex);
      return relativePath;
    }
    // If 'public' directory is not found, return the original path
    return forwardSlashesPath;
  }

  
  
  // // Example usage:
  // const localFilePath = "D:\\Upskilling\\React\\React Basics\\demo-ecommerce-ui\\public\\assets\\ProductImages\\Apparel\\Adidas Men's Dri-FIT Running Track Pants.jpg";
  // const urlPath = transformImagePath(localFilePath);
  // console.log(urlPath); // Output: /assets/ProductImages/Apparel/Adidas Men's Dri-FIT Running Track Pants.jpg
  