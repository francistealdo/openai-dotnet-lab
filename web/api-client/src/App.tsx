import { useState } from 'react';
import AskAI from './pages/chat/AskAI';
import RecipeGenerator from './pages/recipe/RecipeGenerator';
import ImageGenerator from './pages/image/ImageGenerator';
import './App.css';

function App() {
  const [activeTab, setActiveTab] = useState('ask-ai')

  const handleTabChange = (tab: string) => {
    setActiveTab(tab);
  } 

  return (
    <div className="App">
      <button 
        className={activeTab === 'ask-ai' ? 'active' : ''}
        onClick={() => handleTabChange('ask-ai')}>
          Ask AI
      </button>
      <button 
        className={activeTab === 'generate-recipes' ? 'active' : ''}
        onClick={() => handleTabChange('generate-recipes')}>
        Generate Recipes
      </button>
      <button 
        className={activeTab === 'generate-images' ? 'active' : ''}
        onClick={() => handleTabChange('generate-images')}>
        Generate Images
      </button>
      <div>
        {activeTab === 'ask-ai' && <AskAI />}
        {activeTab === 'generate-recipes' && <RecipeGenerator />}
        {activeTab === 'generate-images' && <ImageGenerator />}
      </div>
    </div>
  )
}

export default App
