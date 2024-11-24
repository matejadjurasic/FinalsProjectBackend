import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchMeals, createMeal, deleteMeal } from '../../store/slices/mealsSlice';
import Navbar from '../common/Navbar';
import { AppDispatch } from '../../store';
import { Meal } from '../../lib/types';
import { MEAL_TYPE, NAV_ITEMS } from '../../lib/constants';
import MealModal from './MealModal'; 
import TopImage from '../common/TopImage';
import DatePicker from '../common/DatePicker';
import AddMeal from './AddMeal';
import MealsList from './MealsList';

export default function Log() {
    const dispatch = useDispatch<AppDispatch>();
    const meals = useSelector((state: any) => state.meals.meals);
    const loading = useSelector((state: any) => state.meals.loading);
    const [selectedDate, setSelectedDate] = useState<string>(new Date().toISOString().split('T')[0]);
    const [newMeal, setNewMeal] = useState<Meal>({id: 0,  calories: 0, protein: 0, carbs: 0, fat: 0, mealType: MEAL_TYPE.BREAKFAST, dateTime: new Date().toISOString(),});
    const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
    const [selectedMeal, setSelectedMeal] = useState<Meal | null>(null);

    useEffect(() => {
        const formattedDate = new Date(selectedDate).toISOString();
        dispatch(fetchMeals(formattedDate));
    }, [dispatch, selectedDate]);

    const handleInputChange = (e: React.ChangeEvent<HTMLSelectElement | HTMLInputElement>) => {
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
            <Navbar items={NAV_ITEMS} />
            <TopImage imageUrl='/images/9.png'/>
            <div className="flex flex-col h-screen bg-gray-100 md:flex-row">
                <div className="w-full md:w-1/3 p-8 bg-gray-800 shadow-md">
                    <h2 className="mb-4 text-3xl font-bold text-gray-100">Log Your Meals</h2>
                    <DatePicker selectedDate={selectedDate} onDateChange={(date) => setSelectedDate(date)} />
                    <AddMeal newMeal={newMeal} onInputChange={handleInputChange} onAddMeal={handleAddMeal} />
                </div>
                <MealsList meals={meals} loading={loading} onDeleteMeal={handleDeleteMeal} onOpenModal={openModal} />
                {isModalOpen && selectedMeal && (
                    <MealModal mealId={selectedMeal.id} onClose={closeModal} />
                )}
            </div>
        </div>
    );
}