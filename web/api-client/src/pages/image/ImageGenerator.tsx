import React, { useEffect, useState } from 'react';
import api from '../../services/api';

function ImageGenerator() {
  const [prompt, setPrompt] = useState('');
  const [imageUrl, setImageUrl] = useState<string | null>(null);

  const generateImage = async () => {
    try {
      const response = await api.get(`generate-image`, { params: { prompt }, responseType: 'blob' }); 
      const imageUrl = URL.createObjectURL(response.data);
      setImageUrl(imageUrl);
    } catch (error) {
      console.error('Error generating image:', error);
    }
  };

  useEffect(() => {
    return () => {
      if (imageUrl) {
        URL.revokeObjectURL(imageUrl);
      }
    };
  }, [imageUrl]);

  return (
    <div>
      <h2>Image Generator</h2>
      <input
        type="text"
        value={prompt}
        onChange={(e) => setPrompt(e.target.value)}
        placeholder="Enter image prompt..."
      />
      <button onClick={generateImage}>Generate Image</button>

      <div className="image-grid">
        {imageUrl && <img src={imageUrl} alt="Generated" />}
      </div>  
    </div>
  );
}

export default ImageGenerator;