import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchMealItemsByMealId, createMealItem, deleteMealItem } from '../../store/slices/mealItemsSlice';
import { fetchIngredients } from '../../store/slices/ingredientsSlice';
import { Meal, MealItem, Ingredient } from '../../lib/types';
import { AppDispatch } from '../../store';
import { fetchMealById } from '../../store/slices/mealsSlice';
import Button from '../common/Button';
import ErrorDisplay from '../error/ErrorDisplay';

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
    const errors = useSelector((state: any) => state.mealItems.error);
    const validationErrors = useSelector((state: any) => state.mealItems.validationErrors);

    useEffect(() => {
        if (mealId) {
            dispatch(fetchMealItemsByMealId(mealId));
            dispatch(fetchIngredients());
            dispatch(fetchMealById(mealId));
        }
    }, [dispatch, mealId]);

    const handleAddMealItem = () => {
        if (meal && selectedIngredientId) {
            const newMealItem: MealItem = {
                amount,
                mealId: meal.id,
                ingredientId: selectedIngredientId,
            };
            dispatch(createMealItem(newMealItem)).then(() => {
                dispatch(fetchMealById(meal.id)); 
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
        <div className="fixed z-40 inset-0 flex items-center justify-center bg-black bg-opacity-50">
            <div className="bg-gray-800 text-gray-100 p-6 rounded shadow-md w-96">
                <h2 className="text-lg font-bold mb-4">{meal.mealType}</h2>
                <p>Calories: {Math.round(meal.calories)}</p>
                <p>Protein: {Math.round(meal.protein)}g</p>
                <p>Carbs: {Math.round(meal.carbs)}g</p>
                <p>Fat: {Math.round(meal.fat)}g</p>
                <h3 className="text-md font-semibold mt-4">Meal Items:</h3>
                <ErrorDisplay error={errors} validationErrors={validationErrors}/>
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
                    className="text-gray-900 border rounded p-2 mb-2 w-full"
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
                    className="text-gray-900 border rounded p-2 mb-4 w-full"
                />
                <div className="flex justify-end">
                    <Button type="button" onClick={onClose} className="mr-2 text-gray-500">Cancel</Button>
                    <Button onClick={handleAddMealItem} variant='primary'>Add Meal Item</Button>
                </div>
            </div>
        </div>
    );
};

export default MealModal;