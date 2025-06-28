import React from 'react';
import { Meal } from '../../lib/types';
import Accordion from 'react-bootstrap/Accordion';
import Button from '../common/Button';
import { useSelector } from 'react-redux';
import ErrorDisplay from '../error/ErrorDisplay';

interface MealsListProps {
    meals: Meal[];
    loading: boolean;
    onDeleteMeal: (id: number) => void;
    onOpenModal: (meal: Meal) => void;
}

const MealsList: React.FC<MealsListProps> = ({ meals, loading, onDeleteMeal, onOpenModal }) => {
    const errors = useSelector((state: any) => state.meals.error);
    const validationErrors = useSelector((state: any) => state.meals.validationErrors);

    return (
        <div className="w-full md:w-2/3 p-8 overflow-y-auto bg-gray-800"> 
            <h3 className="text-xl font-bold text-gray-100">Meals:</h3>
            <ErrorDisplay error={errors} validationErrors={validationErrors}/>
            {loading ? (
                <p style={{ color: 'white' }}>Loading meals...</p>
            ) : (
                <Accordion defaultActiveKey="0">
                    {meals.map((meal: Meal, index: number) => (
                        <Accordion.Item key={meal.id} eventKey={index.toString()}>
                            <Accordion.Header>{meal.mealType}</Accordion.Header>
                            <Accordion.Body>
                                <p className='text-lg font-semibold'>Calories: {Math.round(meal.calories)}</p>
                                <p className='text-lg font-semibold'>Protein: {Math.round(meal.protein)}g</p>
                                <p className='text-lg font-semibold'>Carbs: {Math.round(meal.carbs)}g</p>
                                <p className='text-lg font-semibold'>Fat: {Math.round(meal.fat)}g</p>
                                <Button variant='primary' attribute='mb-2' onClick={() => onOpenModal(meal)}>
                                    Add Food
                                </Button>
                                <Button variant='danger' onClick={() => onDeleteMeal(meal.id)}>
                                    Delete Meal
                                </Button>
                            </Accordion.Body>
                        </Accordion.Item>
                    ))}
                </Accordion>
            )}
        </div>
    );
};

export default MealsList;