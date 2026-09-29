import React, { useState } from 'react'; 
import api from '../../services/api';

function AskAI() {

  const [prompt, setPrompt] = useState('');
  const [chatResponse, setChatResponse] = useState('');

  const askAICommand = async () => {
    try {
      const response = await api.get(`ask-ai-options`, { params: { prompt } });
      const data = await response.data;
      console.log('AI Response:', data);
      setChatResponse(data);
    } catch (error) {
      console.error('Error asking AI:', error);
    }
  }

  return (
    <div>
      <h2>Ask AI</h2>
      <input
        type="text"
        value={prompt}
        onChange={(e) => setPrompt(e.target.value)}
        placeholder="Ask a question..."
      />
      <button onClick={askAICommand}>Ask AI</button>

      <div className="output">
        {chatResponse && <p>{chatResponse}</p>}
      </div>
    </div>
  );
}

export default AskAI;