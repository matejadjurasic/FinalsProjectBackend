import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchMealItemsByMealId, createMealItem, deleteMealItem } from '../../store/slices/mealItemsSlice';
import { fetchIngredients } from '../../store/slices/ingredientsSlice';
import { Meal, MealItem, Ingredient } from '../../lib/types';
import { AppDispatch } from '../../store';
import { fetchMealById } from '../../store/slices/mealsSlice';

interface MealModalProps {
    mealId: number;
    onClose: () => void;
}

const MealModal: React.FC<MealModalProps> = ({ mealId, onClose }) => {
    const dispatch = useDispatch<AppDispatch>();
    const meal = useSelector((state: any) => state.meals.meals.find((m: Meal) => m.id === mealId));
    const mealItems = useSelector((state: any) => state.mealItems.mealItems);
    const ingredients = useSelector((state: any) => state.ingredients.ingredients);
    const [selectedIngredientId, setSelectedIngredientId] = useState<number | null>(null);
    const [amount, setAmount] = useState<number>(0);

    useEffect(() => {
        if (mealId) {
            dispatch(fetchMealItemsByMealId(mealId));
            dispatch(fetchIngredients());
            dispatch(fetchMealById(mealId));
        }
    }, [dispatch, mealId]);

    const handleAddMealItem = () => {
        if (meal && selectedIngredientId && amount > 0) {
            const newMealItem: MealItem = {
                amount,
                mealId: meal.id,
                ingredientId: selectedIngredientId,
            };
            dispatch(createMealItem(newMealItem)).then(() => {
                // Refetch meals after adding the meal item
                dispatch(fetchMealById(meal.id)); // Pass the correct date
            });
            setSelectedIngredientId(null);
            setAmount(0);
        }
    };

    const handleDeleteMealItem = (ingredientId: number) => {
        if (meal) {
            dispatch(deleteMealItem({ mealId: meal.id, ingredientId })).then(() => {
                // Refetch the meal after deleting the meal item
                dispatch(fetchMealById(meal.id));
            });
        }
    };

    if (!meal) return null;

    return (
        <div className="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50">
            <div className="bg-white p-6 rounded shadow-md w-96">
                <span className="close cursor-pointer" onClick={onClose}>&times;</span>
                <h2 className="text-lg font-bold mb-4">{meal.mealType}</h2>
                <p>Calories: {Math.round(meal.calories)}</p>
                <p>Protein: {Math.round(meal.protein)}g</p>
                <p>Carbs: {Math.round(meal.carbs)}g</p>
                <p>Fat: {Math.round(meal.fat)}g</p>
                <h3 className="text-md font-semibold mt-4">Meal Items</h3>
                <ul className="mb-4">
                {mealItems.map((item: MealItem) => {
                        const ingredient = ingredients.find((ing: Ingredient) => ing.id === item.ingredientId);
                        return (
                            <li key={item.ingredientId} className="flex justify-between items-center">
                                <span>
                                    {ingredient ? ingredient.name : `Ingredient ID: ${item.ingredientId}`} - Amount: {item.amount}g
                                </span>
                                <button 
                                    onClick={() => handleDeleteMealItem(item.ingredientId)} 
                                    className="text-red-500 ml-2"
                                >
                                    Delete
                                </button>
                            </li>
                        );
                    })}
                </ul>
                <h3 className="text-md font-semibold">Add Meal Item</h3>
                <select
                    onChange={(e) => setSelectedIngredientId(Number(e.target.value))}
                    value={selectedIngredientId || ''}
                    className="border rounded p-2 mb-2 w-full"
                >
                    <option value="" disabled>Select Ingredient</option>
                    {ingredients.map((ingredient:Ingredient) => (
                        <option key={ingredient.id} value={ingredient.id}>{ingredient.name}</option>
                    ))}
                </select>
                <input
                    type="number"
                    value={amount}
                    onChange={(e) => setAmount(Number(e.target.value))}
                    placeholder="Amount in grams"
                    className="border rounded p-2 mb-4 w-full"
                />
                <div className="flex justify-end">
                    <button type="button" onClick={onClose} className="mr-2 text-gray-500">Cancel</button>
                    <button onClick={handleAddMealItem} className="bg-blue-500 text-white rounded px-4 py-2">Add Meal Item</button>
                </div>
            </div>
        </div>
    );
};

export default MealModal;