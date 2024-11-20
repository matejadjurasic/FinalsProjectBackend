import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchMeals, createMeal, deleteMeal } from '../store/slices/mealsSlice';
import Navbar from './common/Navbar';
import Button from './common/Button';
import { AppDispatch } from '../store';
import { Meal } from '../lib/types';
import { MEAL_TYPE } from '../lib/constants';
import MealModal from './common/MealModal'; // Import the MealModal component
import Accordion from 'react-bootstrap/Accordion';

export default function Log() {
    const dispatch = useDispatch<AppDispatch>();
    const meals = useSelector((state: any) => state.meals.meals);
    const loading = useSelector((state: any) => state.meals.loading);
    const [selectedDate, setSelectedDate] = useState<string>(new Date().toISOString().split('T')[0]);
    const [newMeal, setNewMeal] = useState<Meal>({id: 0,  calories: 0, protein: 0, carbs: 0, fat: 0, mealType: MEAL_TYPE.BREAKFAST, dateTime: new Date().toISOString(),});
    const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
    const [selectedMeal, setSelectedMeal] = useState<Meal | null>(null);

    useEffect(() => {
        const formattedDate = new Date(selectedDate).toISOString(); // Format date for API call
        dispatch(fetchMeals(formattedDate));
    }, [dispatch, selectedDate]);

    const handleDateChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSelectedDate(e.target.value);
    };

    const handleInputChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
        const { name, value } = e.target;
        setNewMeal((prev) => ({
            ...prev,
            [name]: value,
        }));
    };

    const handleAddMeal = () => {
        if (newMeal.mealType) {
            const { id, ...mealData } = newMeal;
            dispatch(createMeal({ ...mealData, dateTime: new Date(selectedDate).toISOString() }));
            setNewMeal({ id: 0 , calories: 0, protein: 0, carbs: 0, fat: 0, mealType: MEAL_TYPE.BREAKFAST, dateTime: new Date().toISOString() });
        }
    };

    const handleDeleteMeal = (id: number) => {
        dispatch(deleteMeal(id));
    };

    const openModal = (meal: Meal) => {
        setSelectedMeal(meal);
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setIsModalOpen(false);
        setSelectedMeal(null);
    };

    return (
        <div className="flex flex-col h-screen bg-gray-100">
            <Navbar items={[{ label: 'Home', path: '/' }, { label: 'Log', path: '/log' }, { label: 'Stats', path: '/stats' }]} />
            <img src="/images/7.png" alt="Description" className="w-full h-40 object-cover" />
        <div className="flex flex-col h-screen bg-gray-100 md:flex-row"> {/* Change to flex-row for side-by-side layout */}
        
        
        
            <div className="w-full md:w-1/3 p-8 bg-gray-800 shadow-md"> {/* Left section for logging meals */}
                <h2 className="mb-4 text-2xl font-bold text-gray-100">Log Your Meals</h2>

                <div className="mb-4">
                    <label className="block text-sm font-medium text-gray-100">Select Date:</label>
                    <input
                        type="date"
                        value={selectedDate}
                        onChange={handleDateChange}
                        max={new Date().toISOString().split('T')[0]} // Prevent future dates
                        className="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring focus:ring-blue-200"
                    />
                </div>

                <div className="mb-4">
                    <h3 className="text-lg font-semibold text-gray-100">Add a New Meal</h3>
                    <div>
                        <label className="block text-sm font-medium text-gray-100">Meal Type:</label>
                        <select
                            name="mealType"
                            className="w-full px-3 py-2 mt-1 bg-gray-300 border rounded-md focus:outline-none focus:ring focus:ring-blue-200"
                            value={newMeal.mealType}
                            onChange={handleInputChange}
                            required
                        >
                            {Object.values(MEAL_TYPE).map((type) => (
                                <option key={type} value={type}>{type}</option>
                            ))}
                        </select>
                    </div>
                    <Button onClick={handleAddMeal} className="mt-2 text-gray-100">Add Meal</Button>
                </div>
            </div>

            <div className="w-full md:w-2/3 p-8 overflow-y-auto bg-gray-800"> {/* Right section for meal cards */}
                <h3 className="text-lg font-semibold text-gray-100">Meals for {selectedDate}</h3>
                {loading ? (
                    <p>Loading meals...</p>
                ) : (
                    <Accordion defaultActiveKey="0">
                        {meals.map((meal: Meal, index: number) => (
                            <Accordion.Item key={meal.id} eventKey={index.toString()}>
                                <Accordion.Header>{meal.mealType}</Accordion.Header>
                                <Accordion.Body>
                                    <p>Calories: {Math.round(meal.calories)}</p>
                                    <p>Protein: {Math.round(meal.protein)}g</p>
                                    <p>Carbs: {Math.round(meal.carbs)}g</p>
                                    <p>Fat: {Math.round(meal.fat)}g</p>
                                    <Button className="mt-2" onClick={(e) => { e.stopPropagation(); handleDeleteMeal(meal.id); }}>
                                        Delete Meal
                                    </Button>
                                    <Button className="mt-2" onClick={(e) => { e.stopPropagation(); openModal(meal); }}>
                                        Add Food
                                    </Button>
                                </Accordion.Body>
                            </Accordion.Item>
                        ))}
                    </Accordion>    
                )}
            </div>

            {isModalOpen && selectedMeal && (
                <MealModal mealId={selectedMeal.id} onClose={closeModal} />
            )}
        </div>
        </div>
    );
}