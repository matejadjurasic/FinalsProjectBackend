import React from 'react';
import Button from '../common/Button';
import { MEAL_TYPE } from '../../lib/constants';

interface AddMealProps {
    newMeal: { mealType: string; calories: number; protein: number; carbs: number; fat: number; };
    onInputChange: (e: React.ChangeEvent<HTMLSelectElement | HTMLInputElement>) => void;
    onAddMeal: () => void;
}

const AddMeal: React.FC<AddMealProps> = ({ newMeal, onInputChange, onAddMeal }) => {
    return (
        <div className="mb-4">
            <h3 className="text-xl font-bold text-gray-100">Add a New Meal</h3>
            <div>
                <label className="block text-sm font-medium text-gray-100">Meal Type:</label>
                <select
                    name="mealType"
                    className="w-full font-semibold px-3 mb-3 py-2 mt-1 bg-gray-300 border rounded-md focus:outline-none focus:ring focus:ring-blue-200"
                    value={newMeal.mealType}
                    onChange={onInputChange}
                    required
                >
                    {Object.values(MEAL_TYPE).map((type) => (
                        <option key={type} value={type}>{type}</option>
                    ))}
                </select>
            </div>
            <Button onClick={onAddMeal} variant='primary'>Add Meal</Button>
        </div>
    );
};

export default AddMeal;