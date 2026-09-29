import React, { useState } from 'react'; 
import api from '../../services/api';
import ReactMarkdown from 'react-markdown';

function RecipeGenerator() {
  const [ingredients, setIngredients] = useState('');
  const [cuisine, setCuisine] = useState('');
  const [ dietaryRestrictions, setDietaryRestrictions ] = useState('');

  const [recipe, setRecipe] = useState('');

  const generateRecipe = async () => {
    try {
      const response = await api.get(`generate-recipe`, { params: { ingredients, cuisine, dietaryRestrictions } }); 
      const data = await response.data;      
      console.log('AI Response:', data);
      setRecipe(data);
    } catch (error) {
      console.error('Error generating recipe:', error);
    }
  };

  return (
    <div>
      <h2>Recipe Generator</h2>
      <input
        type="text"
        value={ingredients}
        onChange={(e) => setIngredients(e.target.value)}
        placeholder="Enter ingredients..."
      />
      <input
        type="text"
        value={cuisine}
        onChange={(e) => setCuisine(e.target.value)}
        placeholder="Enter cuisine..."
      />
      <input
        type="text"
        value={dietaryRestrictions}
        onChange={(e) => setDietaryRestrictions(e.target.value)}
        placeholder="Enter dietary restrictions..."
      />
      <button onClick={generateRecipe}>Generate Recipe</button>

      <div className="output">
        {recipe && <ReactMarkdown>{recipe}</ReactMarkdown>}
      </div>
    </div>
  );
}

export default RecipeGenerator;